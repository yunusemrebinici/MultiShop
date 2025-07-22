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
	public class RemoveOrderingCommandHandle : IRequestHandler<RemoveOrderingCommand>
	{
		private readonly IRepository<Ordering>_repository;

		public RemoveOrderingCommandHandle(IRepository<Ordering> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
		{
			var remove = await _repository.GetByIdAsync(request.OrderingId);
			await _repository.DeleteAsync(remove);
		}
	}
}
