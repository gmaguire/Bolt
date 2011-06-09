namespace Bolt.Core.WebServers
{
    public interface IWebServerStartInfo
    {
        int Port { get; set; }

        string LocalPath { get; set; }
    }
}