using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        public string email { get; set; }
        public string password { get; set; }
        public string confirm_password { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
    }
}
