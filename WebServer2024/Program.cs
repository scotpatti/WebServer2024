//DO NOT MODIFY THIS FILE! I WILL CHECK
using System.Threading;

namespace WebServer2023
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var token = cts.Token;
            if (args.Length > 0 && args[0] == "Linux")
            {
                Constants.PATH_CHAR = @"/";
            }
            WebServerMain ws = new WebServerMain();
            ws.Start(token);
        }
    }
}
