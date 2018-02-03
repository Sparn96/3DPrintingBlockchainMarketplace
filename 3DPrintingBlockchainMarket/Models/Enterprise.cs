using _3DPrintingBlockchainMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models
{
    public class Enterprise : UserEditableDataRow
    {
        public Enterprise()
        {
            Employees = new HashSet<ApplicationUser>();
        }
        public Guid IdEnterprise { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVerified { get; set; }

        public ApplicationUser VerifiedBy { get; set; }
        public string VerifiedById { get; set; }

        public ICollection<ApplicationUser> Employees { get; set; }
    }
}
