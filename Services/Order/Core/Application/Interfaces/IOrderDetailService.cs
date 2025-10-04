using Application.Features.CQRS.Quaries.OrderDetailQuaries;
using Application.Features.CQRS.Results.OrderDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IOrderDetailService
	{
		Task <List<GetOrderDetailByOrderingIdQueryResult>> GetOrderDetailListByOrderingId(int id);
	}
}
