using Application.Features.CQRS.Results.OrderDetailResults;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
	public class OrderDetailService : IOrderDetailService
	{
		private readonly OrderContext _context;

		public OrderDetailService(OrderContext context)
		{
			_context = context;
		}

		public async Task<List<GetOrderDetailByOrderingIdQueryResult>> GetOrderDetailListByOrderingId(int id)
		{
			var result = await _context.OrderDetails.Where(x=>x.OrderingId==id).ToListAsync();
			return result.Select(x=> new GetOrderDetailByOrderingIdQueryResult
			{
				OrderingId = x.OrderingId,
				OrderDetailId=x.OrderDetailId,
				ProductAmount=x.ProductAmount,
				ProductId=x.ProductId,
				ProductName=x.ProductName,
				ProductPrice=x.ProductPrice,
				ProductTotalPrice=x.ProductTotalPrice,
			
			}).ToList();
		}
	}
}
