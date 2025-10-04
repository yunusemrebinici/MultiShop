using Application.Features.CQRS.Commands.OrderDetailCommands;
using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class CreateOrderDetailCommandHandle
	{
		private readonly IRepository<OrderDetail>_repository;

		public CreateOrderDetailCommandHandle(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		
        public async Task Handle(CreateOrderDetailCommand createOrderDetail)
		{
			await _repository.CreateAsync(new OrderDetail
			{
				OrderingId = createOrderDetail.OrderingId,
				ProductAmount = createOrderDetail.ProductAmount,
				ProductId = createOrderDetail.ProductId,
				ProductName = createOrderDetail.ProductName,
				ProductPrice = createOrderDetail.ProductPrice,
				ProductTotalPrice = createOrderDetail.ProductTotalPrice,
				AddressId=createOrderDetail.AddressId,
			});
		}

	}
}
