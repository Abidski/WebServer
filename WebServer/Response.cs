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
        string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\WebServer\\Website";
        Byte[] responseBuffer = null;
        string statusCode;
        int contentLength;
        string contentType;
        




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
                Console.WriteLine("path valid");
                GetRoute(request,handler);
            }
            else
            {
                
                Console.WriteLine("Does not exist");
                statusCode = "400 Bad Request";}

        }

        public void GetRoute(Request request,Socket handler)
        {
            if (request.uri.EndsWith("/") || request.uri.EndsWith("/index.html"))
            {
                
                var body = File.ReadAllText(path + "\\index.html");
                var bodyLength = Encoding.UTF8.GetBytes(body).Length;
                var response = $"HTTP/1.1 200 OK\r\nContent-Type: text/html\r\nContent-Lenght: {bodyLength}\r\n\r\n{body}"; 
                var echoBytes = Encoding.UTF8.GetBytes(response);
                handler.Send(echoBytes, echoBytes.Length, SocketFlags.None);
            } else {
                var body = File.ReadAllText(path + request.uri);
                var bodyLength = Encoding.UTF8.GetBytes(body).Length;
                var response = $"HTTP/1.1 200 OK\r\nContent-Type: text/html\r\nContent-Lenght: {bodyLength}\r\n\r\n{body}";
                var echoBytes = Encoding.UTF8.GetBytes(response);
                handler.Send(echoBytes, echoBytes.Length, SocketFlags.None);
            }
        }
    }
}
