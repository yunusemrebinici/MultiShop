using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontends.DTO.CATALOG.FeatureSliderDTOS
{
	public class ResultFeatureSliderDto
	{
		public string FeatureSliderId { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public bool Status { get; set; }

		public bool Featured { get; set; }
	}
}
