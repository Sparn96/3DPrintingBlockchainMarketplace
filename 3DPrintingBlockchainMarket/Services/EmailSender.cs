using _3DPrintingBlockchainMarket.Models;
using _3DPrintingBlockchainMarket.Models.EmailViewModels;
using Microsoft.Extensions.Options;
using RazorLight;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public AuthMessageSenderOptions Options { get; }

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {

            return Execute(Options.SendGridKey, subject, message, email);
        }

        public async Task Execute(string apiKey, string subject, string message, string email, List<Attachment> attachments = null)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("noreply@3dobj.com", "3D Obj"),
                Subject = subject,
                Attachments = attachments,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            var response = await client.SendEmailAsync(msg);
            
        }

        public Task SendConfirmationEmailAsync(ApplicationUser user, string callback_url)
        {
            var engine = new RazorLightEngineBuilder()
              .UseMemoryCachingProvider()
              .Build();


            string template = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "wwwroot", "Templates", "Emails", "Account", "ConfirmationEmail.cshtml"));
            EmailConfirmationViewModel model = new EmailConfirmationViewModel()
            {
                FirstName = user.FirstName,
                CallbackLink = callback_url,
                UnsubscribeLink = "www.google.com"

            };

            string result = engine.CompileRenderAsync("Confirmation", template, model).Result;

            return Execute(Options.SendGridKey, "Confirm Your Account", result, user.Email);
        }

        public Task SendModelConfirmationAsync(ApplicationUser user, UploadModelConfirmation model)
        {
            var engine = new RazorLightEngineBuilder()
              .UseMemoryCachingProvider()
              .Build();


            string template = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "wwwroot", "Templates", "Emails", "Model", "ModelConfirmation.cshtml"));

            string result = engine.CompileRenderAsync("Confirmation", template, model).Result;

            List<Attachment> ATT = new List<Attachment>();
            foreach(var imglnk in model.ImageUrls)
            {
                string base64String = string.Empty;
                // Convert Image to Base64
                using (FileStream image = new FileStream(Path.Combine("wwwroot", "images", "ObjectImages", imglnk), FileMode.Open))
                {
                    MemoryStream ms = new MemoryStream();
                    image.CopyTo(ms);
                    Attachment a = new Attachment();
                    a.Content = Convert.ToBase64String(ms.ToArray());
                    a.ContentId = imglnk;
                    a.Filename = imglnk;
                    a.Type = "image/jpeg";
                    ATT.Add(a);
                }
                    
            }
            

            return Execute(Options.SendGridKey, "Congrats On Your Upload!", result, user.Email, ATT);
        }
    }
    public class AuthMessageSenderOptions
    {
        public string SendGridKey { get; set; }
        public string SendGridUser { get; set; }
    }

}
