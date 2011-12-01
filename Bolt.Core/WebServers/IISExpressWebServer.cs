using System;
using System.Diagnostics;
using System.IO;

namespace Bolt.Core.WebServers
{
    public class IISExpressWebServer : IWebServer
    {
        private readonly string _serverPath;

        private Process _process;

        public IISExpressWebServer()
        {
            var progFiles = Environment.Is64BitOperatingSystem
                                ? Environment.SpecialFolder.ProgramFilesX86
                                : Environment.SpecialFolder.ProgramFiles;

            _serverPath = Path.Combine(Environment.GetFolderPath(progFiles), @"IIS Express\iisexpress.exe");

            if (!File.Exists(_serverPath))
            {
                throw  new FileNotFoundException("IIS Express not found. Please install IIS Express");
            }
        }

        public void Launch(IWebServerStartInfo startInfo)
        {
            var args = string.Format("/path:\"{0}\" /port:{1}", startInfo.LocalPath, startInfo.Port);
            var processStartInfo = new ProcessStartInfo(_serverPath, args);

            _process = new Process { StartInfo = processStartInfo };
            _process.Start();
        }

        public void Shutdown()
        {
            _process.CloseMainWindow();
            _process.Dispose();
        }
    }
}