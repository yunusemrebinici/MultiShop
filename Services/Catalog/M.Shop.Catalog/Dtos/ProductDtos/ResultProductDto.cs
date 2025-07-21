using M.Shop.Catalog.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace M.Shop.Catalog.Dtos.ProductDtos
{
	public class ResultProductDto
	{
		public string ProductID { get; set; }

		public string CategoryID { get; set; }

		public string ProductName { get; set; }

		public decimal ProductPrice { get; set; }

		public string ProductImageUrl { get; set; }

		public string ProductDescription { get; set; }
	}
}
