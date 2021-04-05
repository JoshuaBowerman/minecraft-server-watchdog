using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace minecraft_server_watchdog.Pages
{
    public class DetailsModel : PageModel
    {
        public void OnGet()
        {
            int id = int.Parse(Request.Query["id"]);

            if (Request.Query["action"] == "start")
            {
                ServerManager.instances[id].StartServer();
            }
            if (Request.Query["action"] == "stop")
            {
                ServerManager.instances[id].StopServer();

            }

            ViewData["name"] = ServerManager.instances[id].info.ServerName;
            ViewData["desc"] = ServerManager.instances[id].info.Description;
            ViewData["state"] = ServerManager.instances[id].getServerState();
            ViewData["pack"] = ServerManager.instances[id].info.Modpack;
            ViewData["java"] = ServerManager.instances[id].info.JavaVer;
            ViewData["minr"] = ServerManager.instances[id].info.MinRam;
            ViewData["maxr"] = ServerManager.instances[id].info.MaxRam;
            ViewData["ars"] = ServerManager.instances[id].info.AutoRestart;
            ViewData["as"] = ServerManager.instances[id].info.AutoStart;
            ViewData["jar"] = ServerManager.instances[id].info.jarLoc;


        }
    }
}
