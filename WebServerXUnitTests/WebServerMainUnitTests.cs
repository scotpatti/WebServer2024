using Xunit;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System;
using System.Threading;
using WebServer2023;
using ExtensionsLibrary;

namespace WebServerXUnitTests
{
    public class WebServerMainUnitTests
    {
        public static CancellationTokenSource cts;
        public static CancellationToken token;
        public static WebServerMain server;
        public static Task task;
        public WebServerMainUnitTests()
        {
            if (cts is null)
            {
                cts = new CancellationTokenSource();
                token = cts.Token;
            }
            if (server is null)
            {
                server = new WebServerMain();
                Action action = () => { server.Start(token); };
                task = new Task(action);
                task.Start();
            }
        }

        [Fact]
        public void NULL_TEST()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            var stream = client.GetStream();
            byte[] content = Encoding.ASCII.GetBytes("\0");
            stream.Write(content);
            stream.Flush();
            byte[] response = new byte[client.ReceiveBufferSize];
            stream.Read(response, 0, response.Length);
            string resString = Encoding.ASCII.GetString(response).TrimEnd((char)0);
            client.Close();
            Assert.StartsWith("HTTP/1.0 400 Bad Request\r\n\r\n", resString);
            var expected = File.ReadAllText(@"wwwroot\Error400.html");
            Assert.EndsWith(expected, resString);
        }

        [Fact]
        public void OK_TEST()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            client.WriteString(TestCases.OK_DEFAULT_TEST);
            var response = client.ReadString();
            Assert.StartsWith("HTTP/1.0 200 Ok\r\n", response);
            var file = File.ReadAllText("wwwroot/index.html");
            Assert.EndsWith(file, response);
        }

        [Fact]
        public void OK_INDEX_TEST()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            client.WriteString(TestCases.OK_INDEX_TEST);
            var response = client.ReadString();
            Assert.StartsWith("HTTP/1.0 200 Ok\r\n\r\n", response);
            var file = File.ReadAllText("wwwroot/index.html");
            Assert.EndsWith(file, response);
        }

        [Fact]  
        public void OK_DEFAULT_NO_HEADER_TEST()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            client.WriteString(TestCases.OK_DEFAULT_NO_HEADER_TEST);
            var response = client.ReadString();
            Assert.StartsWith("HTTP/1.0 200 Ok\r\n\r\n", response);
            var file = File.ReadAllText("wwwroot/index.html");
            Assert.EndsWith(file, response);
        }

        [Fact]
        public void OK_DEFAULT_MULTI_HEADER_TEST()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            client.WriteString(TestCases.OK_INDEX_MULTI_HEADER_TEST);
            var response = client.ReadString();
            Assert.StartsWith("HTTP/1.0 200 Ok\r\n\r\n", response);
            var file = File.ReadAllText("wwwroot/index.html");
            Assert.EndsWith(file, response);
        }

        [Fact]
        public void ER_400_TEST()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            client.WriteString(TestCases.ER_400_TEST);
            var response = client.ReadString();
            Assert.StartsWith("HTTP/1.0 400 Bad Request\r\n\r\n", response);
            var file = File.ReadAllText("wwwroot/Error400.html");
            Assert.EndsWith(file, response);
        }

        [Fact]
        public void ER_400_TEST2()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            client.WriteString(TestCases.ER_400_TEST2);
            var response = client.ReadString();
            Assert.StartsWith("HTTP/1.0 400 Bad Request\r\n\r\n", response);
            var file = File.ReadAllText("wwwroot/Error400.html");
            Assert.EndsWith(file, response);
        }

        [Fact]
        public void ER_400_TEST3()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            client.WriteString(TestCases.ER_400_TEST3);
            var response = client.ReadString();
            Assert.StartsWith("HTTP/1.0 400 Bad Request\r\n\r\n", response);
            var file = File.ReadAllText("wwwroot/Error400.html");
            Assert.EndsWith(file, response);
        }

        [Fact]
        public void ER_404_TEST()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            client.WriteString(TestCases.ER_404_TEST);
            var response = client.ReadString();
            Assert.StartsWith("HTTP/1.0 404 Not Found\r\n\r\n", response);
            var file = File.ReadAllText("wwwroot/Error404.html");
            Assert.EndsWith(file, response);
        }

        [Fact]
        public void ER_ZERO_WIDTH_SPACE_TEST()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            client.WriteString(TestCases.ER_ZERO_WIDTH_SPACE_TEST);
            var response = client.ReadString();
            Assert.StartsWith("HTTP/1.0 400 Bad Request\r\n\r\n", response);
            var file = File.ReadAllText("wwwroot/Error400.html");
            Assert.EndsWith(file, response);
        }

        [Fact]
        public void ER_BACKSPACE_CHAR_TEST()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            client.WriteString(TestCases.ER_BACKSPACE_CHAR_TEST);
            var response = client.ReadString();
            Assert.StartsWith("HTTP/1.0 400 Bad Request\r\n\r\n", response);
            var file = File.ReadAllText("wwwroot/Error400.html");
            Assert.EndsWith(file, response);
        }

        [Fact]
        public void ER_CTRL_CHAR_TEST()
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 8080);
            client.WriteString(TestCases.ER_CTRL_CHAR_TEST);
            var response = client.ReadString();
            Assert.StartsWith("HTTP/1.0 400 Bad Request\r\n\r\n", response);
            var file = File.ReadAllText("wwwroot/Error400.html");
            Assert.EndsWith(file, response);
        }
    }
}
