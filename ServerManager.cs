using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace minecraft_server_watchdog
{
    public static class ServerManager
    {
        public static List<ServerInstance> instances = new List<ServerInstance>();

        /*
         * MonitoredFolder: The location that contains all server instances
         * 
         */
        public static void Initialize(string MonitoredFolder)
        {
            string[] folders = Directory.GetDirectories(MonitoredFolder);
            foreach(string candidite in folders)
            {
                ServerInfo info = new ServerInfo(candidite);
                if (info.exists)
                {
                    instances.Add(new ServerInstance(info));
                }
            }
        }


        //Auto starts the instances that define for it.
        public static void AutoStart()
        {
            foreach(ServerInstance instance in instances)
            {
                if (instance.info.AutoStart)
                {
                    instance.StartServer();
                }
            }
        }

        public static void StopAll()
        {
            foreach(ServerInstance instance in instances)
            {
                instance.StopServer();
            }
        }

    }
}
