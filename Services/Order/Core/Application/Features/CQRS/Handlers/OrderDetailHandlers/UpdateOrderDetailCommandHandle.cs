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
	public class UpdateOrderDetailCommandHandle
	{
		private readonly IRepository<OrderDetail> _repository;

		public UpdateOrderDetailCommandHandle(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetail)
		{
			var value = await _repository.GetByIdAsync(updateOrderDetail.OrderDetailId);
			value.OrderingId = updateOrderDetail.OrderingId;
	        value.ProductId = updateOrderDetail.ProductId;
			value.ProductName = updateOrderDetail.ProductName;
			value.ProductAmount = updateOrderDetail.ProductAmount;
			value.ProductPrice = updateOrderDetail.ProductPrice;
			value.ProductTotalPrice = updateOrderDetail.ProductTotalPrice;
			await _repository.UpdateAsync(value);	
		}
	}
}
