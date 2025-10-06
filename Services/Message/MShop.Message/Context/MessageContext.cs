using Microsoft.EntityFrameworkCore;
using MShop.Message.Entities;

namespace MShop.Message.Context
{
	public class MessageContext:DbContext
	{
		public MessageContext(DbContextOptions<MessageContext> options):base(options) 
		{ 
		
		
		}
		
		public DbSet<UserMessage> Messages { get; set; }	
		
	}
}
