using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models.Json
{
    public class UploadModelJson
    {
        public string model_license_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string pricing_unit_of_measure_id { get; set; }
        public decimal? token_price { get; set; }
        public List<string> tags { get; set; }
    }
}
