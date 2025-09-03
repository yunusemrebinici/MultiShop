using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontends.DTO.CATALOG.SpecialOfferDTOS
{
	public class UpdateSpecialOfferDto
	{
		public string SpecialOfferId { get; set; }

		public string Title { get; set; }

		public string SubTitle { get; set; }

		public string ImageUrl { get; set; }
	}
}
