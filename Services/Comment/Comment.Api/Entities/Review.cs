namespace Comment.Api.Entities
{
	public class Review
	{
		public int ReviewID { get; set; }

		public string ProductId { get; set; }

		public string Name { get; set; }

		public string Comments { get; set; }

		public int Point { get; set; }

		public DateTime Date { get; set; }

		public bool Status { get; set; }

		public string? ImageUrl { get; set; }

	}
}
