using PlateformService.Models;
using Microsoft.EntityFrameworkCore;

namespace PlateformService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("PlateformService");
        }
        public DbSet<Plateform> Plateforms { get; set; }
    }
}
