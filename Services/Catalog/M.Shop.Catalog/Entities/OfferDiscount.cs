using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace M.Shop.Catalog.Entities
{
	public class OfferDiscount
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string OfferDiscountId { get; set; }

		public string ImageUrl { get; set; }

		public string Title { get; set; }

		public string SubTitle { get; set; }
	}

}
