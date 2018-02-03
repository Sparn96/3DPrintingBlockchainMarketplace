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
            //_EmailSender.SendModelConfirmationAsync("mitchell@marshhome.net");
            return Json(new { result = "yes"});
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
