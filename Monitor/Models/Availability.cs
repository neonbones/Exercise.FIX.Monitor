using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitor.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public Site Site { get; set; }
        public bool State { get; set; }
    }
}
