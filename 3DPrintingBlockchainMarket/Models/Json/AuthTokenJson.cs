using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Models.Json
{
    public class AuthTokenJson
    {
        public Guid auth_token { get; set; }
        public DateTime expiration { get; set; }
        public string object_hash { get; set; }
    }
}
