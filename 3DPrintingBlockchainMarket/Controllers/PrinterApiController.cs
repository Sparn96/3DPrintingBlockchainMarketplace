using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using _3DPrintingBlockchainMarket.Models;
using _3DPrintingBlockchainMarket.Services;
using _3DPrintingBlockchainMarket.Models.Json;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;

namespace _3DPrintingBlockchainMarket.Controllers
{
    public class PrinterApiController : Controller
    {
        private UserManager<ApplicationUser> _UserManager { get;  }
        private IConsumableLicense _ConsumableLicService { get;  }
        private IAuthTokenService _AuthTokenService { get;  }
        private IObjectModelService _ObjectModelService { get; }
        public PrinterApiController(UserManager<ApplicationUser> um,
            IConsumableLicense icls,
            IAuthTokenService iau,
            IObjectModelService ioms)
        {
            _ConsumableLicService = icls;
            _AuthTokenService = iau;
            _UserManager = um;
            _ObjectModelService = ioms;
        }
        [HttpGet]
        public JsonResult AuthenticatePrintToken(Guid consumable_license, string user_id)
        {
            //Need code that checks consumable_license with the database of tokens to see if valid
            //If valid, cross reference consumable_license to see if matched with correct user_id
            var lic = _ConsumableLicService.Get(consumable_license);
            if (lic == null) return Json(new { result = "Failure", reason = "Not A real token" });
            if (lic.CreatedById == user_id)
            {
                DateTime Expr = DateTime.UtcNow.AddHours(2); // Timeout period
                //User is valid, User that created is the user the purchased
                AuthorizationToken newToken = new AuthorizationToken()
                {
                    AuthUserId = user_id,
                    CreatedById = user_id,
                    LastModifiedById = user_id,
                    DateExpires = Expr,
                    ObjectModeId = lic.ObjectModelId,
                    ConsumableLicenseId = lic.IdConsumableLicense
                };
                newToken = _AuthTokenService.Add(newToken);
                //Send new token back to the awaiting printer
                AuthTokenJson newAuthToken = new AuthTokenJson()
                {
                    expiration = Expr, auth_token = newToken.IdAuthToken, object_hash = _ObjectModelService.Get(lic.ObjectModelId).ObjectHash
                };
                return Json(newAuthToken);
            }
            else
            {
                JsonResult unauth = Json(new { result = "Failure", reason = "Unathorized" });
                unauth.StatusCode = 401;
                return unauth;
            }
        }
        [HttpGet]
        public async Task<IActionResult> AuthenticatedAndReadyToPrintRequest(Guid auth_token_id)
        {
            //If they are ready to print... send the actial object back.. dont encrypt, THis will be for when the BlockChain takes too long for a single requets.

            var Auth = _AuthTokenService.Get(auth_token_id);
            if (Auth == null) return Json(new { result = "Failure", reason = "Invalid Token" });
            else
            {

                //Blockchain was successful; Send the response
                if (_ConsumableLicService.ConsumeUse(Auth.ConsumableLicenseId))
                {
                    if (new TransactionController().WriteTransaction(Auth.ObjectModeId, Auth.AuthUserId))
                    {
                        byte[] FileBytes = System.IO.File.ReadAllBytes(Path.Combine("UploadedModles", "User", Auth.ObjectModeId + ".stl"));
                        SHA256Managed sha = new SHA256Managed();
                        string hash = BitConverter.ToString(sha.ComputeHash(FileBytes.ToArray())).Replace("-", String.Empty);

                        return File(FileBytes, "application/octet-stream");
                    }
                    else
                    {
                        return Json(new { result = "Failure", reason = "Blockchain Failed Insert Record." });
                    }
                }
                else return Json(new { result = "Failure", reason ="Token out of uses" }); // right Error code?
                
            }
        }
        [HttpGet]
        public JsonResult PrintingFinished(Guid auth_token_id)
        {
            throw new NotImplementedException();
            //mark the token as used and delete the token
        }
    }
}


