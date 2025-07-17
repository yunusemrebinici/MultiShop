using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace M.Shop.Catalog.Entities
{
	public class ProductDetail
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public  string  ProductDetailID{ get; set; }

		public string ProductDescription { get; set; }

		public string ProductID { get; set; }

		public string ProductInformation { get; set; }
	}
}
