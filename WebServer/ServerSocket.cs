using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace WebServer
{
    public class ServerSocket
    {
        const int port = 3000;

        public static async void StartServer()
        {
            IPAddress localIpAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(localIpAddress, port);
            Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endPoint);
            socket.Listen(100);
            Console.WriteLine("IP: " + localIpAddress.ToString() + "\nPort: " + port);
            var handler = await socket.AcceptAsync();
            while (true)
            {
                var buffer = new byte[1024];
                var arr = new ArraySegment<byte>(buffer, 0, buffer.Length);
                var received = await handler.ReceiveAsync(arr, SocketFlags.None);
                var request = Encoding.UTF8.GetString(buffer, 0, received);
                Console.WriteLine(request);

          
                

            }

        }

    }
}
