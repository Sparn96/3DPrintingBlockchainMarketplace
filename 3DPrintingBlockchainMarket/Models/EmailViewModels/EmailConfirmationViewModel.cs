using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models.EmailViewModels
{
    public class EmailConfirmationViewModel
    {
        public string FirstName { get; set; }
        public string UnsubscribeLink { get; set; }
        public string CallbackLink { get; set; }
    }
}
