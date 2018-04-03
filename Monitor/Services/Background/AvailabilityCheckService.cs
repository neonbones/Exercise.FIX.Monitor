using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monitor.Models;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace Monitor.Services.Background
{
    public class AvailabilityCheckService : IHostedService
    {
        private readonly IServiceProvider _provider;
        private GlobalSettings ConfigSettings { get; set; }

        public AvailabilityCheckService(IServiceProvider serviceProvider, IOptions<GlobalSettings> settings)
        {
            _provider = serviceProvider;
            ConfigSettings = settings.Value;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while(true)
            {
                using (IServiceScope scope = _provider.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetRequiredService<WebAppContext>();
                    var sites = await _context.Sites.ToListAsync();

                    Parallel.ForEach(sites, (site) =>
                    {
                        GetStatus(site, cancellationToken);
                    });
                }
                await Task.Delay(ConfigSettings.DelayTime, cancellationToken);
            }                    
        }

        public Task GetStatus(Site site, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        WebRequest request = WebRequest.Create(site.Name);

                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                        if (response == null || response.StatusCode != HttpStatusCode.OK)
                        {
                             Log(site, false);
                        }
                        else
                        {
                             Log(site, true);
                        }
                    }
                    catch
                    {
                        // WebExceptions handling
                         Log(site, false);
                    }
                    finally
                    {
                        await Task.Delay(site.RefreshTime, cancellationToken);
                    }
                }
            });           
        }

        private void Log(Site site, bool availability)
        {
            using (IServiceScope scope = _provider.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<WebAppContext>();
                Availability siteAvailability = _context.Availabilities.FirstOrDefault(x => x.SiteId == site.Id);
                if (siteAvailability == null)
                {
                    siteAvailability = new Availability { SiteId = site.Id, State = availability };
                    _context.Availabilities.Add(siteAvailability);
                    _context.SaveChanges();
                }
                else
                {
                    siteAvailability.State = availability;
                    _context.Update(siteAvailability);
                    _context.SaveChanges();
                }
            }                             
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        } 
    }
}
