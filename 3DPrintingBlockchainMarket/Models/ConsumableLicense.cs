using _3DPrintingBlockchainMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models
{
    public class ConsumableLicense : UserEditableDataRow
    {
        public Guid IdConsumableLicense { get; set; }

        public ModelLicense ModelLicense { get; set; }
        public Guid ModelLicenseId { get; set; }

        public int NumberOfUses { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
