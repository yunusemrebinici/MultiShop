namespace Basket.WebApi.Dtos
{
	public class BasketTotalDto
	{
		public string UserId { get; set; }

		public string DiscpımtCode { get; set; }

		public int DiscountRate {  get; set; }

		public List<BasketItemDto> BasketItems { get; set; }

		public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
	}
}
