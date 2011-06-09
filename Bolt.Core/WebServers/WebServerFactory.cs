namespace Bolt.Core.WebServers
{
    public static class WebServerFactory
    {
        public static IWebServer Create()
        {
            // TODO: return appropriate web server
            return new IISWebServer();
        }
    }
}
