using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _3DPrintingBlockchainMarket.Models;
using _3DPrintingBlockchainMarket.Models.AccountViewModels;
using _3DPrintingBlockchainMarket.Models.Json;

namespace _3DPrintingBlockchainMarket.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index()
        {
            UploadModelJson model = new UploadModelJson()
            {
                description = "description",
                model_license_id = "1232-GDEGE43FE43-Ff-vw2gf2...",
                name = "My Model",
                pricing_unit_of_measure_id = "USD",
                tags = new List<string>() { "Green", "Round", "Bouncy" },
                token_price = 0
            };
            return Json(model);
        }

        public JsonResult About()
        {
            return Json(new { page = "About", result = "Success" });
        }

        public JsonResult Contact()
        {
            return Json(new { page = "Contact", result = "Success" });
        }

        public JsonResult Error()
        {
            return Json(new { page = "Error", result = "Failure" });
        }
    }
}
