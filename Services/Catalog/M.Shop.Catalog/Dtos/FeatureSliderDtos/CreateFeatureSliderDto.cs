namespace M.Shop.Catalog.Dtos.FeatureSliderDtos
{
	public class CreateFeatureSliderDto
	{
		
		public string Title { get; set; }

		public string Description { get; set; }

		public string ImageUrl { get; set; }

		public bool Status { get; set; }

		public bool Featured { get; set; }
	}
}
