using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    internal class Request
    {

        public string method { get; set; }
        public string uri { get; set; }
        public string version { get; set; }
        public string host { get; set; }
        public string header { get; set; }
        public string body { get; set; }
        
        public Request(string request)
        {
            this.ParseRequest(request);
        }

        public void ParseRequest(string request)
        {

            var requestSplit = request.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var statusLine = requestSplit[0];
            method = statusLine.Split(' ')[0];
            uri = statusLine.Split(' ')[1];
            version = statusLine.Split(' ')[2];


        }



        public override string ToString()
        {
            return ("Method: " + method + "\nUri: " + uri + "\nVersion: " + version + host);
        }
    }
}
