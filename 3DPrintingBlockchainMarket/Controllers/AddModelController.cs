using _3DPrintingBlockchainMarket.Models.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Controllers
{
    public class AddModelController : Controller
    {
        public AddModelController()
        {


        }

        public async Task<JsonResult> UploadModelAsync(List<IFormFile> files)
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
                //Save the model in the database, allow for upload
            }
            throw new NotImplementedException();
        }

    }
}
