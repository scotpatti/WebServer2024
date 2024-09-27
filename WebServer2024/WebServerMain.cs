// YOU MUST MODIFY THIS FILE SEE THE NOTES IN THE FILE!
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebServer2023
{
    /// <summary>
    /// This class handles the networking parts. It is separate so that you can
    /// separate the concerns of network communication from HTTP 1.0 protocol 
    /// implementation. 
    /// </summary>
    public class WebServerMain : IWebServerMain
    {
        private bool finished = false;
        private TcpListener serverSocket;

        /// <summary>
        /// Donated by your professor. You should pretty much ignore it.
        /// </summary>
        /// <param name="token"></param>
        private void CheckToken(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                Thread.Sleep(1000);
            }
            finished = true;
            serverSocket.Stop();
        }

        /// <summary>
        /// This is called from public static void main to start the server.
        /// DO NOT CHANGE THIS METHOD!!! It already does what it should. 
        /// Handling connections asynchronously allows the server to handle
        /// connections in quick succession (without waiting for a response
        /// to be sent). 
        /// </summary>
        public void Start(CancellationToken token)
        {
            Task.Run(() => CheckToken(token));
            serverSocket = new TcpListener(IPAddress.Any, Constants.PORT);
            serverSocket.Start();
            Console.WriteLine("Web server started.");
            while (!finished)
            {
                try
                {
                    var clientSocket = serverSocket.AcceptTcpClient();
                    _ = HandleConnectionAsync(clientSocket);
                }
                //Thrown when we close the connection in CheckToken. 
                catch (SocketException) { }
            }
            Console.WriteLine("User stopped Server.");

        }

        /// <summary>
        /// You will need to write this one yourself.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task HandleConnectionAsync(TcpClient client)
        {

        }

    }
}
