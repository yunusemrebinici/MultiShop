using Application.Features.CQRS.Results.OrderDetailResults;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class GetOrderDetailQueryHandle
	{
		private readonly IRepository<OrderDetail> _repository;

		public GetOrderDetailQueryHandle(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetOrderDetailQueryResult>> Handle()
		{
			var value = await _repository.GetAllAsync();
			return value.Select(x => new GetOrderDetailQueryResult()
			{
				OrderDetailId = x.OrderDetailId,
				OrderingId = x.OrderingId,
				ProductAmount = x.ProductAmount,
				ProductId = x.ProductId,
				ProductName = x.ProductName,
				ProductPrice = x.ProductPrice,
				ProductTotalPrice = x.ProductTotalPrice,

			}).ToList();
		}
	}
}
