using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Net.Sockets;
using System.Threading;

namespace WebServer
{
    internal class Response
    {
        string path = Path.GetFullPath("Website");
        Byte[] responseBuffer = null;
        string statusCode;
        int contentLength;
        string contentType;
        string body;




        public Response(Request request, Socket handler)
        {
            Console.WriteLine(request.method);

            if (request.method == "POST")
            {
            }
            else if (request.method == "GET") 
            {
                Get(request,handler);
            }

        }

        public void Get(Request request, Socket handler)
        {

            if (File.Exists(path + request.uri)||request.uri=="/")
            {
                statusCode = "200 OK";
                GetRoute(handler);
            }
            else
            {
                Console.WriteLine("Does not exist");
                statusCode = "400 Bad Request";}

        }

        public void GetRoute(Socket handler)
        {
            var response = "HTTP/1.1 200 OK\r\nContent-Type: text/plain\r\n\r\nHello, World!"; ;
            var echoBytes = Encoding.UTF8.GetBytes(response);
            handler.Send(echoBytes, echoBytes.Length, SocketFlags.None);
        }
    }
}
