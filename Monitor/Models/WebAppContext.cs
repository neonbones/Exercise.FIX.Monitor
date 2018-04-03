using Microsoft.EntityFrameworkCore;

namespace Monitor.Models
{
    public class WebAppContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public WebAppContext(DbContextOptions<WebAppContext> options) : base(options) { }
    }
}
