using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontends.DTO.MESSAGE
{
	public class GetMessageDetailByMessageIdDto
	{
		public int UserMessageId { get; set; }

		public string Messages { get; set; }
	}
}
