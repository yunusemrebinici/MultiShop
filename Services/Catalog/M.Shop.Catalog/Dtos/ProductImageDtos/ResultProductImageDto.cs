using M.Shop.Catalog.Entities;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace M.Shop.Catalog.Dtos.ProductImageDtos
{
	public class ResultProductImageDto
	{
		
		public string ProductImagesID { get; set; }

		public string Image1 { get; set; }

		public string Image2 { get; set; }

		public string Image3 { get; set; }

		public string ProductID { get; set; }

	}
}
