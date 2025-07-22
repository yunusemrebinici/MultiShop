using Application.Features.CQRS.Quaries.OrderDetailQuaries;
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
	public class GetOrderDetailByIdQueryHandle
	{
		private readonly IRepository<OrderDetail>_repository;

		public GetOrderDetailByIdQueryHandle(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
		{
			var value = await _repository.GetByIdAsync(getOrderDetailByIdQuery.Id);
			return new GetOrderDetailByIdQueryResult
			{
				OrderDetailId = value.OrderDetailId,
				OrderingId = value.OrderingId,
				ProductAmount = value.ProductAmount,
				ProductId = value.ProductId,
				ProductName = value.ProductName,
				ProductPrice = value.ProductPrice,
				ProductTotalPrice = value.ProductTotalPrice,

			};
		}
	}
}
