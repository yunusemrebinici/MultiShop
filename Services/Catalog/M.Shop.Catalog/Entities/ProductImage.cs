﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace M.Shop.Catalog.Entities
{
	public class ProductImage
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string ProductImagesID { get; set; }
		public string Image1 { get; set; }
		public string Image2 { get; set; }
		public string Image3 { get; set; }

		public string ProductID { get; set; }

		[BsonIgnore]
		public Product Product { get; set; }
	}
}
