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
	public class CreateOrderingCommandHandle : IRequestHandler<CreateOrderingCommand>
	{
		private readonly IRepository<Ordering>_repository;

		public CreateOrderingCommandHandle(IRepository<Ordering> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Ordering
			{
				OrderDate = request.OrderDate,
				TotalPrice = request.TotalPrice,
				UserId = request.UserId,
			});
		}
	}
}
