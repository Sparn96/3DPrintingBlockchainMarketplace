using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models.Json
{
    public class UploadModelJsonResponse
    {
        public bool success { get; set; }
        public List<string> failed_files { get; set; }

    }
}
