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
			var response= await _statisticService.GetAvgProductPrice();
			await Clients.All.SendAsync("ReciveAvgProductPrice", response);
			
		}



	}
}
