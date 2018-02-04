using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Controllers
{
    public class PrinterApiController : Controller
    {
        public PrinterApiController()
        {

        }
        [HttpGet]
        public JsonResult AuthenticatePrintToken(Guid consumable_license, string user_id)
        {
            throw new NotImplementedException();
            //Generte a new token annd send it back for the printer to send once it is ready to print
        }
        [HttpGet]
        public JsonResult AuthenticatedAndReadyToPrintRequest(Guid auth_token_id)
        {
            throw new NotImplementedException();
            //Accept the auth token and send the encrypted 3D object over to the printer.
            //await the addition of the block chain
            //send decrypt key to printer and OK to print.
        }
        [HttpGet]
        public JsonResult PrintingFinished(Guid auth_token_id)
        {
            throw new NotImplementedException();
            //mark the token as used and delete the token
        }
    }
}


