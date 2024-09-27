// YOU MUST MODIFY THIS FILE SEE THE NOTES IN THE FILE!
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WebServer2023
{
    public class RequestHandler : RequestHandlerBase, IRequestHandler
    {
        /// You do need to implement what is in the IRequestHander including Properties
        
        /// <summary>
        /// See notes in IRequestHandler and RequestHandlerBase
        /// </summary>
        /// <param name="request"></param>
        public RequestHandler(string request) : base(request)
        {

        }

        /// <summary>
        /// See notes in IRequestHandler and RequestHandlerBase
        /// </summary>
        /// <param name="method"></param>
        public void SetMethod(string method)
        {

        }

        /// <summary>
        /// See notes in IRequestHandler and RequestHandlerBase
        /// </summary>
        /// <returns></returns>
        public string GetResponse()
        {
            return ""; // This is just a place holder. You will need to change this.
        }

        /// <summary>
        /// See notes in IRequestHandler and RequestHandlerBase
        /// </summary>
        /// <returns></returns>
        public bool GetResource()
        {
            return false; // This is just a place holder. You will need to change this.
        }

        /// <summary>
        /// I used this for debugging. Just kind of nice to have around. If you
        /// are not familiar with this. It means you can call to stream on this
        /// object and log it to the Console easily. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Method = " + Method.ToString() + "\r\n");
            sb.Append("Path = " + Path + "\r\n");
            sb.Append("HTTP Version = " + HttpVersion + "\r\n");
            sb.Append("Request Headers = " + "\r\n");
            foreach (var s in ReqHeaders)
            {
                sb.Append("   " + s);
            }
            return sb.ToString();
        }
    }
}
