using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
	public class OrderContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost,1440;initial Catalog=MShopOrderDb;User=sa;Password=123456789Yunus.;");

			
		}
		public DbSet<Address>Addresses { get; set; }

		public DbSet<OrderDetail>OrderDetails { get; set; }

		public DbSet<Ordering>Orderings { get; set; }
	}
}
