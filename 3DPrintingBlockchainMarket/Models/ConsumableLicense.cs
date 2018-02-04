using _3DPrintingBlockchainMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models
{
    public class ConsumableLicense : UserEditableDataRow
    {
        public ConsumableLicense()
        {
            AuthorizationTokens = new HashSet<AuthorizationToken>();
        }
        public Guid IdConsumableLicense { get; set; }

        public ModelLicense ModelLicense { get; set; }
        public Guid ModelLicenseId { get; set; }

        public ObjectModel ObjectModel { get; set; }
        public Guid ObjectModelId { get; set; }

        public int NumberOfUses { get; set; }
        public DateTime ExpirationDate { get; set; }

        public ICollection<AuthorizationToken> AuthorizationTokens { get; set; }
    }
}
