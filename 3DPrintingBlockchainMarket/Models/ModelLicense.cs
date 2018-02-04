using _3DPrintingBlockchainMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models
{
    public class ModelLicense : DataRow
    {
        public ModelLicense()
        {
            ObjectModelsUnderThisLicense = new HashSet<ObjectModel>();
            DistributedLicenses = new HashSet<ConsumableLicense>();
        }
        public Guid IdLicense { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateValidUnil { get; set; }

        //Associated Enterprise?

        public ICollection<ObjectModel> ObjectModelsUnderThisLicense { get; set; }
        public ICollection<ConsumableLicense> DistributedLicenses { get; set; }
    }
}
