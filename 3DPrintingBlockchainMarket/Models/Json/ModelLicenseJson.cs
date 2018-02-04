using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models.Json
{
    public class ModelLicenseJson
    {
        public ModelLicenseJson(ModelLicense model)
        {
            id_license = model.IdLicense;
            name = model.Name;
            description = model.Description;
            date_valid_until = model.DateValidUnil;
        }
        public Guid id_license { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime? date_valid_until { get; set; }
    }
}
