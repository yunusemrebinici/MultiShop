using Comment.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comment.Api.Concrete
{
	public class CommentContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost,1442;initial Catalog=MshopComment;User=sa;Password=123456Yunus.;");
		}

		public DbSet<Review>Reviews { get; set; }
	}
}
