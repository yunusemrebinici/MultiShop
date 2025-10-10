using Microsoft.AspNetCore.SignalR;
using MShop.SignalR.Services;

namespace MShop.SignalR.Hubs
{
	public class SignalRHub:Hub
	{
		private readonly IStatisticService _statisticService;

		public SignalRHub(IStatisticService statisticService)
		{
			_statisticService = statisticService;
		}

		public async Task Statistics()
		{
			var productAvg= await _statisticService.GetAvgProductPrice();
			await Clients.All.SendAsync("ReciveAvgProductPrice", productAvg);

			var brandCount= await _statisticService.GetBrandCount();
			await Clients.All.SendAsync("ReciveBrandCount", brandCount);

			var categoryCount= await _statisticService.GetCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

			var contactCount= await _statisticService.GetContactCount();
			await Clients.All.SendAsync("ReceiveContactCount", contactCount);

			var lastCreatedProductName= await _statisticService.GetLastCreatedProductName();
			await Clients.All.SendAsync("ReceiveLastProductName", lastCreatedProductName);
			
		}



	}
}
