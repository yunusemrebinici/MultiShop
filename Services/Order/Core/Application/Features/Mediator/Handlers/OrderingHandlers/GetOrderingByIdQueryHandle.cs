using Application.Features.Mediator.Quaries.OrderingQuaries;
using Application.Features.Mediator.Results.OrderingResults;
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
	public class GetOrderingByIdQueryHandle : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
	{
		private readonly IRepository<Ordering>_repository;

		public GetOrderingByIdQueryHandle(IRepository<Ordering> repository)
		{
			_repository = repository;
		}

		public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
		{
		     var value= await _repository.GetByIdAsync(request.Id);
			return new GetOrderingByIdQueryResult
			{
				OrderDate = value.OrderDate,
				OrderingId = value.OrderingId,
				TotalPrice = value.TotalPrice,
				UserId = value.UserId,

			};
		}
	}
}
