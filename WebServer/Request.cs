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

        public string[] requests = new string[0];
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
