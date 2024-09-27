//DO NOT MODIFY THIS FILE! I WILL CHECK
using System.Collections.Generic;

namespace WebServer2023
{
    // I used an ENUM for my method. Why? Because I only wanted you to answer 
    // GET and HEAD requests.
    public enum METHOD
    {
        GET,
        HEAD,
    }
    interface IRequestHandler
    {
        // Holds the Methed type requsted See enum above. 
        METHOD Method { get; set; }
        // Holds the Path e.g. "/index.html"
        string Path { get; set; }
        // Holds the version of https e.g. "1.0" or "1.1"
        float HttpVersion { get; set; }
        // Holds a list of Request Headers: E.g. "Content-Type: text/html\r\n"
        List<string> ReqHeaders { get; set; }
        int ResponseCode { get; set; }
        string ResponseMessage { get; set; }
        string ResponsePage { get; set; }

        /// NOTE: The constructor does do quite a bit of work. See notes in 
        /// AbstractClass: RequestHandlerBase

        /// Sets the Method variable to one of the enums based on text sent
        /// in the request
        public void SetMethod(string method);

        /// creates the complete response that will be sent back to the browser
        /// This includes everything: Response Line and Body!
        public string GetResponse();

        /// Tries to read into the file from the path and returns true if it 
        /// did, and false if it did not. The only side affect is to save the
        /// contents of the file to the ResponsePage variable above. 
        public bool GetResource();
    }
}
