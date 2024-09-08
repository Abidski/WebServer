using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            ServerSocket.StartServer();
            while (true) { }
        }
    }
}
