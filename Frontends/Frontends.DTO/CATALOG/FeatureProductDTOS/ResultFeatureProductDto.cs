﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontends.DTO.CATALOG.FeatureProductDTOS
{
	public class ResultFeatureProductDto
	{
		public string FeatureProductId { get; set; }

		public string Title { get; set; }

		public string ImageUrl { get; set; }

		public decimal Price { get; set; }
	}
}
