using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Monitor.Models;
using Monitor.Models.JsonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor.Services.Background
{
    public class AvailabilityCheckService : IHostedService
    {
        private IHostingEnvironment _env;
        private readonly IServiceProvider _provider;
        private string SavePath = "\\SiteCollection\\";

        public AvailabilityCheckService(IServiceProvider serviceProvider, IHostingEnvironment env)
        {
            _provider = serviceProvider;
            _env = env;
        }

        public async Task StartAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (IServiceScope scope = _provider.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetRequiredService<WebAppContext>();
                    var sites = await _context.Sites.ToListAsync();
                    foreach (var site in sites)
                    {
                        await GetStatus(site.Name, stoppingToken, site.Id.ToString());
                        await Task.Delay(site.RefreshTime, stoppingToken);
                    }                    
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        // Other Help Methods
        private async Task GetStatus(string uri, CancellationToken stoppingToken, string fileName)
        {
            await Task.Factory.StartNew(() =>
            {
                WebRequest request = WebRequest.Create(uri);
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    var webRoot = _env.WebRootPath;
                    string fileNameModified = fileName + ".json";
                    var path = Path.Combine(webRoot + SavePath, fileNameModified);

                    if (response == null || response.StatusCode != HttpStatusCode.OK)
                    {
                        Log(uri, false, path);
                    }
                    Log(uri, true, path);
                }
                catch
                {
                    var webRoot = _env.WebRootPath;
                    string fileNameModified = fileName + ".json";
                    var path = Path.Combine(webRoot + SavePath, fileNameModified);
                    Log(uri, false, path);
                }
               
            });

        }
        private void Log(string uri, bool availability, string path)
        {
            List<AvailabilityState> data = new List<AvailabilityState>();
            data.Add(new AvailabilityState
            {
                Name = uri,
                Availability = availability
            });
            string json = JsonConvert.SerializeObject(data.ToArray());

            File.WriteAllText(path, json);
        }
    }
}
