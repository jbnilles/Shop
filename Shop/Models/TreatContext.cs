using Microsoft.EntityFrameworkCore;
namespace Shop.Models
{
    public class TreatContext : DbContext
    {
        public  DbSet<Treat> Treats { get; set; }
        public  DbSet<Flavor> Flavors { get; set; }
        public  DbSet<TreatFlavor> TreatFlavors { get; set; } 

        public TreatContext(DbContextOptions options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}