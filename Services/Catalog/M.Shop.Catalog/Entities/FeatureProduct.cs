using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace M.Shop.Catalog.Entities
{
	public class FeatureProduct
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string FeatureProductId { get; set; }

		public string Title { get; set; }

		public string ImageUrl { get; set; }

		public decimal Price { get; set; }
	}
}
