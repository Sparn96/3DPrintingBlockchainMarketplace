using _3DPrintingBlockchainMarket.Models;
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
        private IObjectModelService _ObjectModelService { get; }
        private UserManager<ApplicationUser> _UserManager { get; }
        public AddModelController(IObjectModelService iobs, UserManager<ApplicationUser> um)
        {
            _UserManager = um;
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
            List<string> FailedFiles = new List<string>();
            foreach(var file in Directory.GetFiles(filePath))
            {
                //Remove the filepath
                string FileName = file.Remove(0, file.LastIndexOf('/'));
                //remove the file extension 
                FileName = FileName.Remove(FileName.Length - 4);
                using (var stream = new FileStream(file, FileMode.Open))
                {
                    MemoryStream ValidateStream = new MemoryStream();
                    stream.CopyTo(ValidateStream);
                    stream.Position = 0; // Reset the position for reading

                    if (VerifyValid3DModel(ValidateStream))
                    {
                        //Add object to the database
                        ObjectModel obj = _ObjectModelService.Get(FileName);
                        if (obj == null) FailedFiles.Add(FileName);
                        else
                        { // The file is a valid object.. verify the proper user is uploading the file
                            if (_UserManager.GetUserId(User) == obj.CreatedById)
                            {
                                //user is auth to upload the files or make changes
                                SHA256Managed sha = new SHA256Managed();
                                byte[] hash = sha.ComputeHash(stream);
                                obj.ObjectHash = BitConverter.ToString(hash).Replace("-", String.Empty);
                                //obj.StoredFileLocation = 


                            }
                            else
                            {
                                //User is not authorized to make this upload ;; End entire transaction
                                JsonResult result = Json(new { result = "Failure", reason = "User is unathorized to make changes to this Object" });
                                result.StatusCode = 401;
                                return result;
                            }
                        }
                    }
                    else
                    {
                        //Add to failed message list.. use specific model id?
                        FailedFiles.Add(FileName);
                        continue;
                    }
                }
            }
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Json(new { result = "Success", message = $"We received {files.Count} File{((files.Count > 0) ? "s" : "")}"});
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

        public bool VerifyValid3DModel(Stream fileStream)
        {
            //Validate the proper file extention
            //validate leading and trailing bits.
            //validate file size.
            //validate vector patterns
            return true;
        }
    }
}
