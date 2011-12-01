namespace Bolt.Core.WebServers
{
    public static class WebServerFactory
    {
        public static IWebServer Create()
        {
            // TODO: return appropriate web server, perhaps config driven?
            return new VsWebServer();
        }
    }
}
