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
using Newtonsoft.Json;
using Monitor.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Monitor.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebAppContext _context;
        public HomeController(WebAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
            var availability = _context.Availabilities.Include(u => u.Site);

            return View(await availability.ToListAsync());
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
