using Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.DataAccessLayer.Concrete
{
	public class CargoContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost,1441;initial Catalog=MShopCargoDb;User=sa;Password=123456789Yunus.;");
		}

		public DbSet<CargoCompany> CargoCompanies { get; set; }

		public DbSet<CargoDetail> CargoDetail { get; set; } 

		public DbSet<CargoCustomer>CargoCustomers { get; set; }

		public DbSet<CargoOperation>CargoOperations { get; set; }
	}
}
