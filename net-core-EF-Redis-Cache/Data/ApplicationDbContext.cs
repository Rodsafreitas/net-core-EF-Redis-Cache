using Microsoft.EntityFrameworkCore;
using net_core_EF_Redis_Cache.Models;

namespace net_core_EF_Redis_Cache.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Weather> Weather { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weather>().HasKey(w => w.Id);
            base.OnModelCreating(modelBuilder);
        }


    }
}
