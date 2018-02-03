using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _3DPrintingBlockchainMarket.Models;

namespace _3DPrintingBlockchainMarket.Controllers
{
    public class HomeController : Controller
    {
        public JsonResult Index()
        {
            return Json(new { page = "Home", result = "Success" });
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
