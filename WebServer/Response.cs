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
        string path = Path.GetFullPath("Driver.cs");
        Byte[] responseBuffer = null;
        string mime;
        string statusCode;
        int contentLength;
        string contentType;
        string body;




        public Response(Request request, Socket handler)
        {
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
            handler.SendFileAsync(path + "index.html");
        }
    }
}
