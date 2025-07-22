using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Quaries.OrderDetailQuaries
{
	public class GetOrderDetailByIdQuery
	{
		public int Id { get; set; }

		public GetOrderDetailByIdQuery(int id)
		{
			Id = id;
		}
	}
}
