using _3DPrintingBlockchainMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models
{
    public class ObjectModel : UserEditableDataRow
    {
        public ObjectModel()
        {
            AuthorizationTokens = new HashSet<AuthorizationToken>();
            ConsumableLicenses = new HashSet<ConsumableLicense>();
        }
        public Guid IdObjectModel { get; set; }
        public string Name { get; set; }
        public int DownloadCount { get; set; }
        public string ObjectTags { get; set; }
        public string ObjectHash { get; set; }
        public string StoredFileLocation { get; set; }
        public decimal? TokenPrice { get; set; } // The amount needed in order to download a one use token

        public ModelLicense ModelLicense { get; set; }
        public Guid ModelLicenseId { get; set; }

        public UnitOfMeasure PricingUnitOfMeaure { get; set; }
        public string PricingUnitOfMeaureId { get; set; }

        public ICollection<AuthorizationToken> AuthorizationTokens { get; set; }
        public ICollection<ConsumableLicense> ConsumableLicenses { get; set; }

        //Owned by is whomever created the the item, unless it is tied with an enterprise license...

    }
}
