using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;



namespace _3DPrintingBlockchainMarket.Controllers
{
    public class PrinterApiController : Controller
    {
        public PrinterApiController()
        {

        }
        [HttpGet]
        public IActionResult AuthenticatePrintToken(Guid consumable_license, string user_id)
        {
            //Need code that checks consumable_license with the database of tokens to see if valid
            //If valid, cross reference consumable_license to see if matched with correct user_id
            //Currently code makes a random token that is assumed valid


            ///HAND SHAKE PROCESS

            return RedirectToAction("WriteTransaction", "Transaction", new { objectModel_id = consumable_license, User_id = user_id });
            //Generte a new token and send it back for the printer to send once it is ready to print
        }
        [HttpGet]
        public JsonResult AuthenticatedAndReadyToPrintRequest(Guid auth_token_id)
        {


            try
            {



            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


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


