using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _3DPrintingBlockchainMarket.Controllers
{
    public class TransactionController : Controller
    {
        private string BlockChainPath = Path.Combine("Blockchain", "block-chain.bin");
        public TransactionController()
        {

        }

        public bool WriteTransaction(Guid objectModel_id, string User_id)
        {
            TcpClient client = new TcpClient();

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);

            client.Connect(serverEndPoint);

            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(objectModel_id.ToString() + ";" + User_id);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
            return true;
        }


       
    }


    
}
