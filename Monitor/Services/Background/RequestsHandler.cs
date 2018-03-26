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
    public static class RequestsHandler
    {
        private static readonly string SavePath = "\\SiteCollection\\";

        public static async Task GetStatus(string uri, CancellationToken stoppingToken, string fileName, IHostingEnvironment env)
        {
            await Task.Factory.StartNew(() =>
            {
                HandleRequest(uri, stoppingToken, fileName, env);
            });
        }

        private static void HandleRequest(string uri, CancellationToken stoppingToken, string fileName, IHostingEnvironment env)
        {
            var webRoot = env.WebRootPath;
            string fileNameModified = fileName + ".json";
            var path = Path.Combine(webRoot + SavePath, fileNameModified);
            try
            {
                WebRequest request = WebRequest.Create(uri);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response == null || response.StatusCode != HttpStatusCode.OK)
                {
                    Log(uri, false, path);
                }
                else
                {
                    Log(uri, true, path);
                }
            }
            catch
            {
                // WebExceptions handling
                Log(uri, false, path);
            }
        }

        private static void Log(string uri, bool availability, string path)
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
