namespace Bolt.Core.WebServers
{
    public interface IWebServer
    {
        void Launch(IWebServerStartInfo startInfo);

        void Shutdown();
    }
}