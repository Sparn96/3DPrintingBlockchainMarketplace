using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models.Json
{
    public class ModelObjectJson
    {
        public ModelObjectJson(ObjectModel model, string picture_url)
        {
            id_object_model = model.IdObjectModel;
            name = model.Name;
            download_count = model.DownloadCount;
            object_tags = model.ObjectTags;
            token_price = model.TokenPrice;
            model_licence = new ModelLicenseJson(model.ModelLicense);
            pricing_unit_of_measure = model.PricingUnitOfMeaureId;

        }
        public Guid id_object_model { get; set; }
        public string name { get; set; }
        public int download_count { get; set; }
        public string object_tags { get; set; }
        public decimal? token_price { get; set; } 
        public ModelLicenseJson model_licence { get; set; }
        public string pricing_unit_of_measure { get; set; }
        public string picture_url { get; set; }
    }
}
