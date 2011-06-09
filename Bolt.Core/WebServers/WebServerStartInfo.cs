namespace Bolt.Core.WebServers
{
    public class WebServerStartInfo : IWebServerStartInfo
    {
        public int Port { get; set; }

        public string LocalPath { get; set; }
    }
}