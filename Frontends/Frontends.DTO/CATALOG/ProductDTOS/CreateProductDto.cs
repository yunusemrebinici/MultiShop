﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Frontends.DTO.CATALOG.ProductDTOS
{
	public class CreateProductDto
	{
	
		public string CategoryID { get; set; }

		public string ProductName { get; set; }

		public decimal ProductPrice { get; set; }

		public string ProductImageUrl { get; set; }

		public string ProductDescription { get; set; }
	}
}
