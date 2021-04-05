using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minecraft_server_watchdog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            List<string> names = new List<string>();
            List<string> icons = new List<string>();
            List<string> descs = new List<string>();
            List<string> stats = new List<string>();

            for(int i = 0; i < ServerManager.instances.Count; i++)
            {
                names.Add(ServerManager.instances[i].info.ServerName);
                icons.Add(ServerManager.instances[i].info.IconLocation);
                descs.Add(ServerManager.instances[i].info.Description);
                stats.Add(ServerManager.instances[i].getServerState() ? "True":"False");
            }
            ViewData["instance-names"] = names;
            ViewData["instance-icons"] = icons;
            ViewData["instance-descs"] = descs;
            ViewData["instance-stats"] = stats;

        }
    }
}
