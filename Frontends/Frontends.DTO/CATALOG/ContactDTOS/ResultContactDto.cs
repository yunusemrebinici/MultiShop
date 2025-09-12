using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontends.DTO.CATALOG.ContactDTOS
{
	public class ResultContactDto
	{
		public string ContactId { get; set; }

		public string Name { get; set; }

		public string Mail { get; set; }

		public string Subject { get; set; }

		public string Message { get; set; }

		public DateTime MessageTime { get; set; }
	}
}
