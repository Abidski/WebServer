using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Threading;
using System.Net.Http;

namespace WebServer
{
    public class ServerSocket
    {
        const int port = 3000;
      
        public static void StartServer()
        {
            CreateServer();
        }

        private async static Task CreateServer()
        {
            IPAddress localIpAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(localIpAddress, port);
            var socket = InitializeSocket(localIpAddress, endPoint);
            var handler = await ConnectSocket(socket);
            await HandleRequest(handler);
            handler.Close();
            socket.Close();
        }



        private static Socket InitializeSocket(IPAddress localIpAddress, IPEndPoint endPoint)
        {
            Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(endPoint);
            socket.Listen(100);
            Console.WriteLine("IP: " + localIpAddress.ToString() + "\nPort: " + port);
            return socket;
        }

        private async static Task<Socket> ConnectSocket(Socket socket)
        {
            var handler = await socket.AcceptAsync();
            return handler;
        }

        public async static Task HandleRequest(Socket handler)
        {

            var buffer = new byte[1024];
            var arr = new ArraySegment<byte>(buffer, 0, buffer.Length);
            var received = await handler.ReceiveAsync(arr, SocketFlags.None);
            var request = Encoding.UTF8.GetString(buffer, 0, received);
            var req = new Request(request);
            new Response(req, handler);
        }
    }
}
