using _3DPrintingBlockchainMarket.Models;
using _3DPrintingBlockchainMarket.Models.EmailViewModels;
using _3DPrintingBlockchainMarket.Models.Json;
using _3DPrintingBlockchainMarket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Controllers
{
    public class AddModelController : Controller
    {
        public enum FileUploadType {UNKOWN, STL, PNG, JPG }
        private IObjectModelService _ObjectModelService { get; }
        private IEmailSender _EmailSender { get; }
        private UserManager<ApplicationUser> _UserManager { get; }
        public AddModelController(IObjectModelService iobs,
            UserManager<ApplicationUser> um,
            IEmailSender ies)
        {
            _UserManager = um;
            _EmailSender = ies;
            _ObjectModelService = iobs;
        }

        /// <summary>
        /// After the object has been successfully uploaded, you can upload the object file(s)
        /// It will verify the object ID by the name of the file and the user submitting the files
        /// </summary>
        /// <param name="files">Filename must be the unique returned ID of the addition confirmaiton</param>
        /// <returns></returns>
        public async Task<JsonResult> UploadModelsAsync(List<IFormFile> files)
        {

            long size = files.Sum(f => f.Length);
            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            // process uploaded files
            List<string> FailedFiles = new List<string>();
            //List of all added objects
            List<string> AddedModelPics = new List<string>();
            foreach (var file in Directory.GetFiles(filePath))
            {
                //Remove the filepath
                string FileNameWithExt = file.Remove(0, file.LastIndexOf('/'));
                //remove the file extension 
                string FileName = FileNameWithExt.Remove(FileNameWithExt.Length - 4);
                using (var stream = new FileStream(file, FileMode.Open))
                {
                    MemoryStream ValidateStream = new MemoryStream();
                    stream.CopyTo(ValidateStream);
                    stream.Position = 0; // Reset the position for reading

                    switch (FindFileType(ValidateStream, FileNameWithExt))
                    {
                        case FileUploadType.STL:
                            {
                                if (!Add3DModelToFile(stream, FileName)) { FailedFiles.Add(FileName); }
                                break;
                            }
                        case FileUploadType.PNG:
                        case FileUploadType.JPG:
                            {
                                string pic = AddPictureRepresentation(stream, FileName);
                                if(String.IsNullOrEmpty(pic)){ AddedModelPics.Add(pic); } else{ FailedFiles.Add(FileName); }
                                break;
                            }
                        default:
                            {
                                FailedFiles.Add(FileName);
                                continue;
                            }
                    }
                }
            }
            UploadModelJsonResponse response = new UploadModelJsonResponse()
            {
                failed_files = new List<string>()
            };
            //Gather the confirmed file picture form the database, send that in an email
            if (AddedModelPics.Count > 0)
            {
                response.success = true;
                ApplicationUser user = await _UserManager.GetUserAsync(User);
                UploadModelConfirmation emailModel = new UploadModelConfirmation()
                {
                    FirstName = user.FirstName,
                    ImageUrls = new List<string>()
                };
                foreach (var pic_file_loc in AddedModelPics)
                {
                    //Load the picture as an absolute url
                    emailModel.ImageUrls.Add(Url.Content(pic_file_loc));
                   
                }
                await _EmailSender.SendModelConfirmationAsync(user, emailModel);
            }
            
            //If there are any error files,  Review them and send response. 
            if(FailedFiles.Count > 0)
            {
                foreach(var error_file_name in FailedFiles)
                {
                    //Add to reuslt Json Object error list
                    response.failed_files.Add(error_file_name);
                }
            }


            return Json(response);
        }

        /// <summary>
        /// Save .STL files to File System
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="FileName"></param>
        /// <param name=""></param>
        /// <returns>Filepath to image</returns>
        private bool Add3DModelToFile(Stream stream, string FileName)
        {

            //Add object to the database
            ObjectModel obj = _ObjectModelService.Get(FileName);
            if (obj == null) return false;
            else
            { // The file is a valid object.. verify the proper user is uploading the file
                if (_UserManager.GetUserId(User) == obj.CreatedById)
                {
                    //user is auth to upload the files or make changes
                    SHA256Managed sha = new SHA256Managed();
                    byte[] hash = sha.ComputeHash(stream);
                    obj.ObjectHash = BitConverter.ToString(hash).Replace("-", String.Empty);
                    //Verify the File Path Exists
                    if (!Directory.Exists("UploadedModles"))
                    {
                        Directory.CreateDirectory("UploadedModles");
                    }
                    if (!Directory.Exists(Path.Combine("UploadedModles", "User")))
                    {
                        Directory.CreateDirectory(Path.Combine("UploadedModles", "User"));
                    }
                    if (!Directory.Exists(Path.Combine("UploadedModles", "Enterprise")))
                    {
                        Directory.CreateDirectory(Path.Combine("UploadedModles", "Enterprise"));
                    }

                    ///FOR NOW -- JUST STORE IN USER DATA -- FIGURTE OUT FILE SYSTEM LATER 
                    //Check if Already Exists
                    string ModelFile = Path.Combine("UploadedModles", "User", FileName + ".stl");
                    MemoryStream tobeWritten = new MemoryStream();
                    stream.CopyTo(tobeWritten);

                    if (System.IO.File.Exists(ModelFile))
                    {
                        //If the file exists, then it is counted as an update, and the old file must be purged >:)
                        //Deleye the old file if it exists
                        System.IO.File.Delete(ModelFile);
                    }
                    // write the file to the file system
                    try { System.IO.File.WriteAllBytes(ModelFile, tobeWritten.ToArray()); } catch (Exception ex) { return false; }

                    //If we got this far, save the ObjectModel 
                    _ObjectModelService.Update(obj, User);

                    return true;

                }
                else
                {
                    //User is not authorized to make this upload ;; End entire transaction
                    return false;
                }
            }
        }
        private string AddPictureRepresentation(Stream stream, string FileName)
        {
            string FilePath = Path.Combine("wwwroot", "images", "ObjectImages", FileName + ".png");
            MemoryStream inMem = new MemoryStream();
            stream.CopyTo(inMem);
            System.IO.File.WriteAllBytes(FilePath, inMem.ToArray());
            return FilePath;
        }
        public JsonResult ConfirmValidModel(UploadModelJson model)
        {
            if(String.IsNullOrEmpty(model.model_license_id)||
                String.IsNullOrEmpty(model.name) ||
                model.tags.Count == 0 ||
                String.IsNullOrEmpty(model.description))
            {
                //Failed the validation
                JsonResult res = Json(new { result = "Failure", reason = "Model does not contain all the proper inforation" });
                res.StatusCode = 406;
                return res;
            }
            else
            {
                ObjectModel objectModel = new ObjectModel()
                {
                    ModelLicenseId = Guid.Parse(model.model_license_id),
                    Name = model.name,
                    PricingUnitOfMeaureId = model.pricing_unit_of_measure_id,
                    TokenPrice = model.token_price
                };
                objectModel.ObjectTags = "";
                foreach (var tag in model.tags)
                {
                    objectModel.ObjectTags += tag + ";";
                }

                try { _ObjectModelService.Add(objectModel, User); } catch { return Json(new { result = "Failure", reason = "Database Save Issue." }); }
                return Json(new { result = "Success" });
                
            }
        }

        public FileUploadType FindFileType(Stream fileStream, string FileNameWithExtension)
        {
            //Validate the proper file extention
            //validate leading and trailing bits.
            //validate file size.
            //validate vector patterns
            return FileUploadType.UNKOWN;
        }
    }
}
