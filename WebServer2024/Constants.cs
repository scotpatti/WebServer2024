/// YOU ARE FREE TO ADD TO THIS IF YOU LIKE
/// PLEASE DO NOT CHANGE WHAT IS HERE
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebServer2023
{
    /// <summary>
    /// This is just here for your benefit! 
    /// It is reqired that you use this PORT for your server!
    /// </summary>
    public static class Constants
    {
        #region Dr. A's Settings and other Useful Regex stuff.

        // The port to use for the server
        public static int PORT = 8080;

        // Unix is "/" and windows is "\" USE THIS IN YOUR PROGRAM! I will 
        // depend on this in the testing environment. I originally wrote this
        // in Windows, but I will test it in 
        public static string PATH_CHAR = @"\";

        public static string UNPRINTABLE = "[\0\u0001\u0002\u0003\u0004\u0005\u0006\u0007\u0008\u0009\u000B\u000C\u000E\u000F\u0010\u0011\u0012\u0013\u0014\u0015\u0016\u0017\u0018\u0019\u001A\u001B\u001C\u001D\u001E\u001F]+";


        // A regular expression that will match requests - to the best of my knowledge
        public static string REQUEST_LINE = @"^(GET|POST|HEAD)\s(\S+)\sHTTP/(\d\.\d)\r\n([^:\r\n]+\s*:\s*[^\r\n]+\r\n)*\r\n";

        // An extension method to CaptureCollection so that I can add it to a list. 
        // I.e. I used this with matching multiple headers. 
        public static List<string> ToList(this CaptureCollection matches)
        {
            List<string> rval = new List<string>();
            foreach (var x in matches)
            {
                rval.Add(x.ToString());
            }
            return rval;
        }

        #endregion
    }
}
