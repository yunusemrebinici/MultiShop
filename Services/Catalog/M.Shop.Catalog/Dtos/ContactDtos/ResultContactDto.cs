namespace M.Shop.Catalog.Dtos.ContactDtos
{
	public class ResultContactDto
	{
		public string ContactId { get; set; }

		public string Name { get; set; }

		public string Mail { get; set; }

		public string Subject { get; set; }

		public string Message { get; set; }

		public DateTime MessageTime { get; set; }
	}
}
