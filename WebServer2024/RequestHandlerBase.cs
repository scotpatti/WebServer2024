//DO NOT MODIFY THIS FILE! I WILL CHECK
using System;

namespace WebServer2023
{
    public abstract class RequestHandlerBase
    {
        //This forces the constructor to exist the way we want it - i.e. taking a string!
        public RequestHandlerBase(string request)
        {
            if (request is null)
            {
                throw new Exception("You must have this working!");
            }
        }

    }
}
