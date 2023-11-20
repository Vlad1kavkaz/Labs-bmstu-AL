using Microsoft.EntityFrameworkCore;
using TaxiModels;

namespace TaxiServices
{
    public class AppDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Car> Cars { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Data Source=localhost; Initial Catalog=lab12; User Id=sa; Password=MyStr0ngPassword!;"); // TODO
        }
    }
}
