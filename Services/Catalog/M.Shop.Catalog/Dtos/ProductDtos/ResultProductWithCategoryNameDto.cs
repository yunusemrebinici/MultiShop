﻿namespace M.Shop.Catalog.Dtos.ProductDtos
{
	public class ResultProductWithCategoryNameDto
	{
		public string ProductID { get; set; }

		public string CategoryName { get; set; }

		public string ProductName { get; set; }

		public decimal ProductPrice { get; set; }

		public string ProductImageUrl { get; set; }

		public string ProductDescription { get; set; }
	}
}
