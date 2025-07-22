using Application.Features.Mediator.Results.OrderingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Quaries.OrderingQuaries
{
	public class GetOrderingQuery:IRequest<List<GetOrderingQueryResult>>
	{
	}
}
