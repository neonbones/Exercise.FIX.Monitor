using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monitor.Models;
using Monitor.Services;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Monitor.Models.JsonModels;
using Newtonsoft.Json;
using Monitor.ViewModels;

namespace Monitor.Controllers
{
    public class HomeController : Controller
    {
        private string SavePath = "\\SiteCollection\\";

        private readonly WebAppContext _context;       
        private IHostingEnvironment _env;
        public HomeController(WebAppContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var sites = _context.Sites;
            List<SiteModel> siteCollection = new List<SiteModel> { };

            foreach (var site in sites)
            {
                var webRoot = _env.WebRootPath;
                string fileNameModified = site.Id.ToString() + ".json";
                var path = Path.Combine(webRoot + SavePath, fileNameModified);

                if (System.IO.File.Exists(path))
                {
                    var json = await System.IO.File.ReadAllTextAsync(path);

                    var state = JsonConvert.DeserializeObject<List<AvailabilityState>>(json);
                    siteCollection.Add(new SiteModel
                    {
                        Name = site.Name,
                        Availability = state[0].Availability
                    });
                }
            }
            return View(siteCollection);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
