using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MohammadrezaTarkhanCRUDTest.DataLayer
{
	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext () : base() { }
		public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) { }



		protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("base"));
		}



		public virtual DbSet<Customer> Customers { get; set; }




		protected override void OnModelCreating (ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new CustomerConfigurations());
		}
	}
}
