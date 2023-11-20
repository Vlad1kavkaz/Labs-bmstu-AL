using System;
using Microsoft.EntityFrameworkCore;
using MySql.Data;

namespace lab13
{
	public class AppDbContext : DbContext
	{
		public DbSet<Car> Cars { get; set; }
		public DbSet<Driver> Drivers { get; set; }
		public DbSet<Ride> Rides { get; set; }

		public AppDbContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=lab12;User Id = sa; Password = MyStr0ngPassword!");
		}
	}
}

