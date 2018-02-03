using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace _3DPrintingBlockchainMarket.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            ObjectModelLastModBy = new HashSet<ObjectModel>();
            ObjectModelCreatedBy = new HashSet<ObjectModel>();
            EnterpriseCreatedBy = new HashSet<Enterprise>();
            EnterpriseLastModBy = new HashSet<Enterprise>();
            EnterpriseVerifiedByUser = new HashSet<Enterprise>();

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IReadOnlyCollection<ObjectModel> ObjectModelCreatedBy { get; set; }
        public IReadOnlyCollection<ObjectModel> ObjectModelLastModBy { get; set; }

        public IReadOnlyCollection<Enterprise> EnterpriseCreatedBy { get; set; }
        public IReadOnlyCollection<Enterprise> EnterpriseLastModBy { get; set; }
        public IReadOnlyCollection<Enterprise> EnterpriseVerifiedByUser { get; set; }
    }
}
