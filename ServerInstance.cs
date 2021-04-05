using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace minecraft_server_watchdog
{
    public class ServerInstance
    {
        private static Dictionary<string, string> JavaLocations = new Dictionary<string,string>()
        {
            {"8","/mnt/java/8/bin/java" },
            {"11","/mnt/java/11/bin/java" }
        };

        public ServerInfo info;
        private Process javaInstance;
        private bool unStarted = true;

        public ServerInstance(ServerInfo template)
        {
            info = template;
            javaInstance = new Process();
            javaInstance.StartInfo.FileName = JavaLocations[info.JavaVer];
            javaInstance.StartInfo.WorkingDirectory = info.ServerFolderLocation;
            javaInstance.StartInfo.Arguments = "-Xms" + info.MinRam + " -Xmx" + info.MaxRam + " " + info.JarArgs + " -jar " + info.jarLoc + " nogui";
            
        }


        public void StopServer()
        {
            unStarted = true;
            javaInstance.StandardInput.WriteLine("stop");
            javaInstance.WaitForExit();
        }

        public void StartServer()
        {
            unStarted = false;
            javaInstance.Start();
        }


        //Whether or not the server is running
        public bool getServerState()
        {
            bool ret = false;
            if(unStarted)
            {
                ret = false;
            }
            else
            {
                ret = !javaInstance.HasExited;
            }

            return ret;
        }

    }
}
