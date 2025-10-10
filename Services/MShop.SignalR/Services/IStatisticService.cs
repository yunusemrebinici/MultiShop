namespace MShop.SignalR.Services
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
