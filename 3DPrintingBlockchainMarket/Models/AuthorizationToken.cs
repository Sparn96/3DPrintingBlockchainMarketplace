using _3DPrintingBlockchainMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models
{
    public class AuthorizationToken : UserEditableDataRow
    {
        public AuthorizationToken()
        {
          
        }

        public Guid IdAuthToken { get; set; }
        public DateTime DateExpires { get; set; }

        public ApplicationUser AuthUser { get; set; }
        public string AuthUserId { get; set; }

        public ObjectModel ObjectModel { get; set; }
        public Guid ObjectModeId { get; set; }
    }
}
