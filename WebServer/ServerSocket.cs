using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    internal class ServerSocket
    {
        const int port = 3000;

        public static async void StartServer()
        {
            // Get ip of local machine
            var hostName = Dns.GetHostName();
            IPHostEntry localhost = await Dns.GetHostEntryAsync(hostName);
            IPAddress localIpAddress = localhost.AddressList[0];

            // Create end point that connects port localhost to port 3000
            IPEndPoint endPoint = new IPEndPoint(localIpAddress, port);

            // Create tcp socket 
            Socket _socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Binds the socket to the endpoint
            _socket.Bind(endPoint);

            // Allow socket to listen to connection
            _socket.Listen(100);

            // Display socket info
            Console.WriteLine("hostname: " + hostName + "\nport: " + port);

            // Accepts incoming socket connection
            var handler = await _socket.AcceptAsync();

            while (true)
            {
                Console.WriteLine("Connected");
            }
        }
    }
}
