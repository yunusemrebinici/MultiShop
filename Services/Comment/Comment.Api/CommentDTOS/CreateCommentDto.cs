namespace Comment.Api.CommentDTOS
{
	public class CreateCommentDto
	{
		

		public string ProductId { get; set; }

		public string Name { get; set; }

		public string Comments { get; set; }

		public int Point { get; set; }

		public DateTime Date { get; set; }

		public bool Status { get; set; }

		public string? ImageUrl { get; set; }
	}
}
