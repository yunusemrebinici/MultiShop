using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontends.DTO.CATALOG.ProductDTOS
{
	public class GetProductsByCategoryDto
	{

		public string ProductID { get; set; }

		public string ProductName { get; set; }

		public decimal ProductPrice { get; set; }

		public string ProductImageUrl { get; set; }
	}
}
