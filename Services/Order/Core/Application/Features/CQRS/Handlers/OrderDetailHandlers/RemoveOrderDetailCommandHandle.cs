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
	public class RemoveOrderDetailCommandHandle
	{
		private readonly IRepository<OrderDetail> _repository;

		public RemoveOrderDetailCommandHandle(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveOrderDetailCommand removeOrderDetail)
		{
			var value = await _repository.GetByIdAsync(removeOrderDetail.OrderDetailId);
			await _repository.DeleteAsync(value);
		}
	}
}
