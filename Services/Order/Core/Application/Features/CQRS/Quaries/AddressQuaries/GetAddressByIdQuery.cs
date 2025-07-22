using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Quaries.AddressQuaries
{
	public class GetAddressByIdQuery
	{
		public int Id { get; set; }

		public GetAddressByIdQuery(int id)
		{
			Id = id;
		}
	}
}
