using Application.Features.Mediator.Commands.OrderingCommands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Handlers.OrderingHandlers
{
	public class UpdateOrderingCommandHandle : IRequestHandler<UpdateOrderingCommand>
	{
		private readonly IRepository<Ordering>_repository;

		public UpdateOrderingCommandHandle(IRepository<Ordering> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
		{
			await _repository.UpdateAsync(new Ordering
			{
				OrderDate = request.OrderDate,
				OrderingId=request.OrderingId,
				TotalPrice = request.TotalPrice,
				UserId = request.UserId,
			});
		}
	}
}
