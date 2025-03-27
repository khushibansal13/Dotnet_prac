using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        public string SendPing()
        {
            // Simulate sending a ping and returning a response
            return "Ping response";
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }
    }
}