using M.Shop.Discount.Entitites;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace M.Shop.Discount.Context
{
	public class DapperContext:DbContext
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public DapperContext(IConfiguration configuration)
		{
			
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("DefaultConnection");
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=EMRE\\SQLEXPRESS01; initial Catalog=MShopDiscountDb;integrated Security=true");

		}
		public DbSet<Coupon> Coupons { get; set; }
		public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
	}
}
