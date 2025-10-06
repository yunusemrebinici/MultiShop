using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontends.DTO.MESSAGE
{
	public class GetMessageByUserId
	{
		public int UserMessageId { get; set; }

		public string ReceiverId { get; set; }

		public string SenderId { get; set; }

		public string Subject { get; set; }

		public string Messages { get; set; }

		public DateTime SendedDate { get; set; }

		public bool IsReaded { get; set; }
	}
}
