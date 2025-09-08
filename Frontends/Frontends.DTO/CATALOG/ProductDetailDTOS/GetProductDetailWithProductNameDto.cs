using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontends.DTO.CATALOG.ProductDetailDTOS
{
	public class GetProductDetailWithProductNameDto
	{
		public string ProductDetailID { get; set; }

		public string ProductID { get; set; }

		public string Description { get; set; }

		public decimal Price{ get; set; }

		public string ProductName { get; set; }
	}
}
