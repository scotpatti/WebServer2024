namespace WebServerXUnitTests
{
    public static class TestCases
    {
        public static string OK_DEFAULT_TEST = "GET / HTTP/1.0\r\nContent-Type: text/html\r\n\r\n";
        public static string OK_INDEX_TEST = "GET /index.html HTTP/1.0\r\nContent-Type: text/html\r\n\r\n";
        public static string OK_DEFAULT_NO_HEADER_TEST = "GET / HTTP/1.0\r\n\r\n";
        public static string OK_INDEX_MULTI_HEADER_TEST = "GET / HTTP/1.0\r\nContent-Type: text/html\r\nUser-Agent: Dr. A Test Suite\r\n\r\n";
        public static string ER_400_TEST = "GET /index.html and other HTTP/1.0\r\n\r\n";
        public static string ER_400_TEST2 = "GET /index.html HTTP/1.0\r\n\r\r";
        public static string ER_400_TEST3 = "GET /index.html HTTP/2.X\r\n\r\n";
        public static string ER_404_TEST = "GET /nothere.html HTTP/1.0\r\nContent-Type: text/html\r\n\r\n";
        public static string ER_ZERO_WIDTH_SPACE_TEST = "GET\u200B/index.html\u200BHTTP/1.0\r\n\r\n";
        public static string ER_BACKSPACE_CHAR_TEST = "GET \b/index.html \bHTTP/1.0\r\n\r\n";
        public static string ER_CTRL_CHAR_TEST = "GET /index.html\u0005 HTTP/1.0\r\n\r\n";
    }
}
