using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    internal class RequestHandler
    {

        string[] requests = new string[0];
        string method;
        string uri;
        string version;
        string host;
        
        public RequestHandler(string request)
        {
            this.ParseRequest(request);
        }

        public void ParseRequest(string request)
        {
            Console.WriteLine("isinde request handler");
            requests = request.Split(' ');
            this.ExtractInfo();
        }

        private void ExtractInfo()
        {
            method = requests[0];
            uri  = requests[1];
            version = requests[2];
            host = requests[3];
            Console.WriteLine(this.ToString()); 
        }

        public override string ToString()
        {
            return ("Method: " + method + "\nUri: " + uri + "\nVersion: " + version + host);
        }


    }
}
