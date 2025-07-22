using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.AddressComands
{
	public class RemoveAddressCommand
	{
		public int AddressId { get; set; }

		public RemoveAddressCommand(int addressId)
		{
			AddressId = addressId;
		}
	}
}
