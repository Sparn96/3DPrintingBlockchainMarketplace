using _3DPrintingBlockchainMarket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models
{
    public class UnitOfMeasure : DataRow
    {
        public UnitOfMeasure()
        {
            ObjectModelPricingUOM = new HashSet<ObjectModel>();
        }
        public string IdUnitOfMeasure { get; set; }
        public int Factor { get; set; }
        public string Description { get; set; }

        public ICollection<ObjectModel> ObjectModelPricingUOM { get; set; }
        
    }
}
