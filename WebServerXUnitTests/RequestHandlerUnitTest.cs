using Xunit;
using System.IO;
using WebServer2023;

namespace WebServerXUnitTests
{
    public class RequestHandlerUnitTest
    {
        #region OK Tests
        [Fact]
        public void OK_DEFAULT_TEST()
        {
            RequestHandler request = new RequestHandler(TestCases.OK_DEFAULT_TEST);
            Assert.Equal(METHOD.GET, request.Method);
            Assert.Equal("/index.html", request.Path);
            Assert.Equal(1.0, request.HttpVersion);
            Assert.Single(request.ReqHeaders);
            Assert.Equal("Content-Type: text/html\r\n", request.ReqHeaders[0]);
            Assert.Equal(200, request.ResponseCode);
            Assert.Equal("Ok", request.ResponseMessage);
            var expected = File.ReadAllText(@"wwwroot\index.html");
            Assert.Equal(expected, request.ResponsePage);
            Assert.True(request.GetResource());
        }

        [Fact]
        public void OK_INDEX_TEST()
        {
            RequestHandler request = new RequestHandler(TestCases.OK_INDEX_TEST);
            Assert.Equal(METHOD.GET, request.Method);
            Assert.Equal("/index.html", request.Path);
            Assert.Equal(1.0, request.HttpVersion);
            Assert.Single(request.ReqHeaders);
            Assert.Equal("Content-Type: text/html\r\n", request.ReqHeaders[0]);
            Assert.Equal(200, request.ResponseCode);
            Assert.Equal("Ok", request.ResponseMessage);
            var expected = File.ReadAllText(@"wwwroot\index.html");
            Assert.Equal(expected, request.ResponsePage);
            Assert.True(request.GetResource());
        }

        [Fact]
        public void OK_DEFAULT_NO_HEADER_TEST()
        {
            RequestHandler request = new RequestHandler(TestCases.OK_DEFAULT_NO_HEADER_TEST);
            Assert.Equal(METHOD.GET, request.Method);
            Assert.Equal("/index.html", request.Path);
            Assert.Equal(1.0, request.HttpVersion);
            Assert.Empty(request.ReqHeaders);
            Assert.Equal(200, request.ResponseCode);
            Assert.Equal("Ok", request.ResponseMessage);
            var expected = File.ReadAllText(@"wwwroot\index.html");
            Assert.Equal(expected, request.ResponsePage);
            Assert.True(request.GetResource());
        }

        [Fact]
        public void OK_INDEX_MULTI_HEADER_TEST()
        {
            RequestHandler request = new RequestHandler(TestCases.OK_INDEX_MULTI_HEADER_TEST);
            Assert.Equal(METHOD.GET, request.Method);
            Assert.Equal("/index.html", request.Path);
            Assert.Equal(1.0, request.HttpVersion);
            Assert.Equal(2, request.ReqHeaders.Count);
            Assert.Equal("Content-Type: text/html\r\n", request.ReqHeaders[0]);
            Assert.Equal("User-Agent: Dr. A Test Suite\r\n", request.ReqHeaders[1]);
            Assert.Equal(200, request.ResponseCode);
            Assert.Equal("Ok", request.ResponseMessage);
            var expected = File.ReadAllText(@"wwwroot\index.html");
            Assert.Equal(expected, request.ResponsePage);
            Assert.True(request.GetResource());
        }
        #endregion

        #region ER Tests
        [Fact]
        public void ER_400_TEST()
        {
            RequestHandler request = new RequestHandler(TestCases.ER_400_TEST);
            //Assert.Equal(METHOD.GET,request.Method); 
            Assert.Equal("/Error400.html",request.Path);
            //Assert.Equal(0, request.HttpVersion);
            Assert.Empty(request.ReqHeaders);
            Assert.Equal(400, request.ResponseCode);
            Assert.Equal("Bad Request", request.ResponseMessage);
            var expected = File.ReadAllText(@"wwwroot\Error400.html");
            Assert.Equal(expected, request.ResponsePage);
            Assert.True(request.GetResource());
        }

        [Fact]
        public void ER_400_TEST2()
        {
            RequestHandler request = new RequestHandler(TestCases.ER_400_TEST2);
            //Assert.Equal(METHOD.GET,request.Method); 
            Assert.Equal("/Error400.html", request.Path);
            //Assert.Equal(0, request.HttpVersion);
            Assert.Empty(request.ReqHeaders);
            Assert.Equal(400, request.ResponseCode);
            Assert.Equal("Bad Request", request.ResponseMessage);
            var expected = File.ReadAllText(@"wwwroot\Error400.html");
            Assert.Equal(expected, request.ResponsePage);
            Assert.True(request.GetResource());
        }

        [Fact]
        public void ER_400_TEST3()
        {
            RequestHandler request = new RequestHandler(TestCases.ER_400_TEST3);
            //Assert.Equal(METHOD.GET,request.Method); 
            Assert.Equal("/Error400.html", request.Path);
            //Assert.Equal(0, request.HttpVersion);
            Assert.Empty(request.ReqHeaders);
            Assert.Equal(400, request.ResponseCode);
            Assert.Equal("Bad Request", request.ResponseMessage);
            var expected = File.ReadAllText(@"wwwroot\Error400.html");
            Assert.Equal(expected, request.ResponsePage);
            Assert.True(request.GetResource());
        }

        [Fact]
        public void ER_404_TEST()
        {
            RequestHandler request = new RequestHandler(TestCases.ER_404_TEST);
            Assert.Equal(METHOD.GET,request.Method); 
            Assert.Equal("/Error404.html", request.Path);
            Assert.Equal(1.0, request.HttpVersion);
            Assert.Single(request.ReqHeaders);
            Assert.Equal(404, request.ResponseCode);
            Assert.Equal("Not Found", request.ResponseMessage);
            var expected = File.ReadAllText(@"wwwroot\Error404.html");
            Assert.Equal(expected, request.ResponsePage);
            Assert.True(request.GetResource());
        }

        [Fact]
        public void ER_ZERO_WIDTH_SPACE_TEST()
        {
            RequestHandler request = new RequestHandler(TestCases.ER_ZERO_WIDTH_SPACE_TEST);
            //Assert.Equal(METHOD.GET, request.Method);
            Assert.Equal("/Error400.html", request.Path);
            //Assert.Equal(1.0, request.HttpVersion);
            Assert.Empty(request.ReqHeaders);
            Assert.Equal(400, request.ResponseCode);
            Assert.Equal("Bad Request", request.ResponseMessage);
            var expected = File.ReadAllText(@"wwwroot\Error400.html");
            Assert.Equal(expected, request.ResponsePage);
            Assert.True(request.GetResource());
        }

        [Fact]
        public void ER_BACKSPACE_CHAR_TEST()
        {
            RequestHandler request = new RequestHandler(TestCases.ER_BACKSPACE_CHAR_TEST);
            //Assert.Equal(METHOD.GET, request.Method);
            Assert.Equal("/Error400.html", request.Path);
            //Assert.Equal(1.0, request.HttpVersion);
            Assert.Empty(request.ReqHeaders);
            Assert.Equal(400, request.ResponseCode);
            Assert.Equal("Bad Request", request.ResponseMessage);
            var expected = File.ReadAllText(@"wwwroot\Error400.html");
            Assert.Equal(expected, request.ResponsePage);
            Assert.True(request.GetResource());
        }

        [Fact]
        public void ER_CTRL_CHAR_TEST()
        {
            RequestHandler request = new RequestHandler(TestCases.ER_CTRL_CHAR_TEST);
            //Assert.Equal(METHOD.GET, request.Method);
            Assert.Equal("/Error400.html", request.Path);
            //Assert.Equal(1.0, request.HttpVersion);
            Assert.Empty(request.ReqHeaders);
            Assert.Equal(400, request.ResponseCode);
            Assert.Equal("Bad Request", request.ResponseMessage);
            var expected = File.ReadAllText(@"wwwroot\Error400.html");
            Assert.Equal(expected, request.ResponsePage);
            Assert.True(request.GetResource());
        }
        #endregion
    }
}
