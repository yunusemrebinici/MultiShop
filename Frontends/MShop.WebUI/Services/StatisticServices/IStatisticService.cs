namespace MShop.WebUI.Services.StatisticServices
{
	public interface IStatisticService
	{
		Task<long> GetBrandCount();

		Task<long> GetCategoryCount();

		Task<long> GetContactCount();

		Task<decimal> GetAvgProductPrice();

		Task<string> GetLastCreatedProductName();
	}
}
