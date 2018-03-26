using Monitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitor.Repository
{
    public interface IWebAppContextRepository
    {
        ICollection<Site> GetAllSites();
        Site AddSite(Site site);
        Site GetSiteByName(string name);
    }
}
