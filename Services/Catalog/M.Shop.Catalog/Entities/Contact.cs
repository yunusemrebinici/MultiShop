using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace M.Shop.Catalog.Entities
{
	public class Contact
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ContactId { get; set; }

		public string Name { get; set; }

		public string Mail {  get; set; }

		public string Subject {  get; set; }

		public string Message { get; set; }

		public DateTime MessageTime { get; set; }
	}
}
