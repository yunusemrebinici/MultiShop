using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace M.Shop.Catalog.Entities
{
	public class Brand
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string BrandId { get; set; }

		public string ImageUrl { get; set; }
	}
}
