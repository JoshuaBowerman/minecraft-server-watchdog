using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace minecraft_server_watchdog
{
    public class ServerInfo
    {
        //These are Set to Their Defaults
        public string ServerName = "Untitled Server";
        public string IconLocation = "";
        public string Description = "";
        public string MinRam = "512M";
        public string MaxRam = "1G";
        public string JavaArgs = "";
        public string JarArgs = "nogui";
        public string JavaVer = "8";
        public string jarLoc = "minecraft_server.*.jar";
        public string MinecraftVersion = "N/A";
        public string Modpack = "Vanilla";
        public bool AutoRestart = false;
        public bool ExperimentalGC = false;
        public string ServerFolderLocation = "";
        public bool exists = false;
        public bool AutoStart = false;

        public ServerInfo(string serverLocation)
        {

            ServerFolderLocation = serverLocation;

            if(File.Exists(serverLocation + "/server.info"))
            {
                exists = true;
                //Parse it
                string[] file = File.ReadAllLines(serverLocation + "/server.info");
                foreach(var line in file)
                {
                    string entry;
                    //try to remove a comment if this line has one
                    if (line.Contains("//")){
                        entry = line.Split("//")[0];
                    }
                    else
                    {
                        entry = line.Trim();
                    }

                    
                    if(entry != "") //Not an empty line
                    {
                        //Make sure it is an entry
                        if (entry.Contains("="))
                        {
                            var v = entry.Split("=", 2);
                            string variable = v[0].Trim();
                            string value = v[1].TrimStart();

                            //parse
                            switch (variable)
                            {
                                case "name":
                                    ServerName = value;
                                    break;
                                case "icon":
                                    IconLocation = serverLocation + "/" + value;
                                    break;
                                case "desc":
                                    Description = value;
                                    break;
                                case "mcver":
                                    MinecraftVersion = value;
                                    break;
                                case "modpack":
                                    Modpack = value;
                                    break;
                                case "executable":
                                    jarLoc = value;
                                    break;
                                case "minRam":
                                    MinRam = value;
                                    break;
                                case "maxRam":
                                    MaxRam = value;
                                    break;
                                case "experGC":
                                    if (value == "true")
                                        JavaArgs += "-XX:+UseG1GC -XX:+UnlockExperimentalVMOptions -XX:MaxGCPauseMillis=100 -XX:+DisableExplicitGC -XX:TargetSurvivorRatio=90 -XX:G1NewSizePercent=50 -XX:G1MaxNewSizePercent=80 -XX:G1MixedGCLiveThresholdPercent=50 -XX:+AlwaysPreTouch";
                                    ExperimentalGC = value == "true";
                                    break;
                                case "java":
                                    JavaVer = value;
                                    break;
                                case "autoRestart":
                                    AutoRestart = value == "true";
                                    break;
                                case "autoStart":
                                    AutoStart = value == "true";
                                    break;
                                default:
                                    break;
                            }
                            //End of switch
                        }   
                    }
                }
                //End of foreach
                
                //Check to see if icon exists and remove the entry otherwise
                if(IconLocation != "" && !File.Exists(serverLocation + "/" + IconLocation))
                {
                    IconLocation = "";
                }



            }
            else
            {
                return;
            }

        }
    }
}
