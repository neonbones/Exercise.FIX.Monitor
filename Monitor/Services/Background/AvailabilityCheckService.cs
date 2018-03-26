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
                        await RequestsHandler.GetStatus(site.Name, stoppingToken, site.Id.ToString(), _env);
                        await Task.Delay(site.RefreshTime, stoppingToken);
                    }                    
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }     
    }
}
