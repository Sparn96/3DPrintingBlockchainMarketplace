using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _3DPrintingBlockchainMarket.Models;
using _3DPrintingBlockchainMarket.Models.AccountViewModels;
using _3DPrintingBlockchainMarket.Models.Json;
using _3DPrintingBlockchainMarket.Services;

namespace _3DPrintingBlockchainMarket.Controllers
{
    public class HomeController : Controller
    {
        IEmailSender _EmailSender;
        public HomeController(IEmailSender es)
        {
            _EmailSender = es;
        }
        public JsonResult Index()
        {
            UploadModelJson model = new UploadModelJson()
            {  description = "Container", model_license_id = "40C03B2D-370D-45B9-9BCC-015DB1FF90B6", name = "Bottle Container", pricing_unit_of_measure_id = "USD", tags = new List<string>() { "Bottle","Container","4 Pack","Pack","Beer","Holder" }, token_price = .10m  };

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
