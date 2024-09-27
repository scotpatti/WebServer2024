//DO NOT MODIFY THIS FILE! I WILL CHECK
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer2023
{
    interface IWebServerMain
    {
        /// This method is implemented for you.
        void Start(CancellationToken token);

        /// <summary>
        /// Write this Yourself. It should completely handle the connection by 
        /// returning an appropriate response and then closing the connection.
        /// NOTE: This should do all the work with the connection, but you should
        /// call:
        ///   IRequest reqHandler = new RequestHandler(request); // request -> full text of the request
        ///   string response = reqHandler.GetResponse();
        /// I.e. most of the work is done in reqHandler constructor and GetResponse. See the IRequestHandler
        /// for more details. 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        Task HandleConnectionAsync(TcpClient client);
    }
}
