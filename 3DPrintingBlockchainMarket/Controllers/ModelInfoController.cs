using _3DPrintingBlockchainMarket.Models;
using _3DPrintingBlockchainMarket.Models.Json;
using _3DPrintingBlockchainMarket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Controllers
{
    public class ModelInfoController : Controller
    {
        private ILicenseService _LicService { get; }
        private IObjectModelService _ObjectModelService { get; }

        public ModelInfoController(IObjectModelService ioms, ILicenseService ils)
        {
            _LicService = ils;
            _ObjectModelService = ioms;
        }

        //Get All Licenses
        public JsonResult GetAllLicenses()
        {
            List<ModelLicenseJson> result = new List<ModelLicenseJson>();
            foreach(var ml in _LicService.GetAll<ModelLicense>())
            {
                result.Add(new ModelLicenseJson(ml));
            }
            return Json(result);
        }
        /// <summary>
        /// Return the top 20 of the result list for tags
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public JsonResult SearchItems(params string[] tags)
        {
            //get All by browse search request
            List<ModelObjectJson> result = new List<ModelObjectJson>();
            foreach(var res in _ObjectModelService.Search(tags))
            {
                //return the picture link as well
                result.Add(new ModelObjectJson(res, Url.Content(Path.Combine("wwwroot", "images", "ObjectImages", res.IdObjectModel + ".png"))));
            }
            return Json(result);
        }
        
        public JsonResult ItemDrilldown(Guid object_model_id)
        {
            var obj = _ObjectModelService.Get(object_model_id);
            if (obj == null) return Json(new { result = "Failure", reason = "No Object was found" });
            else
            {
                ModelObjectJson result = new ModelObjectJson(obj, Url.Content(Path.Combine("wwwroot", "images", "ObjectImages", obj.IdObjectModel + ".png")));
                return Json(result);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetModelFile(Guid object_model_id)
        {
            //Grab the model
            if (System.IO.File.Exists(Path.Combine("UploadedModles", "User", object_model_id + ".stl")))
            {
                using (FileStream fs = new FileStream(Path.Combine("UploadedModles", "User", object_model_id + ".stl"), FileMode.Open))
                {
                    return File(fs, "application/octet-stream");
                }
            }
            else return NotFound();
        }

        //GetAllInfoForItem
        //Drilldown for the item. + 3D model for render purposes?
    }
}
