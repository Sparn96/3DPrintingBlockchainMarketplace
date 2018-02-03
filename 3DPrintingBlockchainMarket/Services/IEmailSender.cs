using _3DPrintingBlockchainMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendConfirmationEmailAsync(ApplicationUser user, string callback_url);
        Task SendModelConfirmationAsync(string email);
    }
}
