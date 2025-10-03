using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.AddressComands
{
	public class CreateAddressCommand
	{


		public string UserId { get; set; }

		public string UserName { get; set; }

		public string UserSurname { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public string District { get; set; }

		public string City { get; set; }

		public string Description { get; set; }

		public string Detail { get; set; }
	}
}
