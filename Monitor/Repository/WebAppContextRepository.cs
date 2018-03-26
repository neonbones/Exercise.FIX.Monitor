using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monitor.Models;

namespace Monitor.Repository
{
    public class WebAppContextRepository : IWebAppContextRepository
    {
        private readonly WebAppContext _context;

        public WebAppContextRepository(WebAppContext context)
        {
            _context = context;
        }

        public Site AddSite(Site site)
        {
            _context.Sites.Add(site);
            _context.SaveChanges();
            return site;
        }

        public ICollection<Site> GetAllSites()
        {
            return _context.Sites.ToList();
        }
        public Site GetSiteByName(string name)
        {
            return _context.Sites.FirstOrDefault(u => u.Name == name);
        }
    }
}
