using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontends.DTO.CATALOG.CommentDTOS
{
	public class ResultCommentDto
	{
		public int ReviewID { get; set; }

		public string ProductId { get; set; }

		public string Name { get; set; }

		public string Comments { get; set; }

		public int Point { get; set; }

		public DateTime date { get; set; }

		public bool Status { get; set; }

		public string? ImageUrl { get; set; }
	}
}
