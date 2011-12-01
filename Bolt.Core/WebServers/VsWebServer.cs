using System;
using System.Diagnostics;
using System.IO;

namespace Bolt.Core.WebServers
{
    public class VsWebServer : IWebServer
    {
        private readonly string _serverPath;

        private Process _process;

        public VsWebServer()
        {
            _serverPath = GetServerPath();
        }

        private static string GetServerPath()
        {
            var progFiles = Environment.Is64BitOperatingSystem
                                ? Environment.SpecialFolder.ProgramFilesX86
                                : Environment.SpecialFolder.ProgramFiles;

            var serverPath = Path.Combine(Environment.GetFolderPath(progFiles), @"Common Files\microsoft shared\DevServer\10.0\WebDev.WebServer40.EXE");

            if (!File.Exists(serverPath))
            {
                throw new FileNotFoundException("Cannot find the Visual Studio web server. Please install Visual Studio 2010.");
            }

            return serverPath;
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
            _process.Kill();
            _process.Dispose();
        }
    }
}
