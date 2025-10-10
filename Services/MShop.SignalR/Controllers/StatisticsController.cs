using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.SignalR.Services;

namespace MShop.SignalR.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		private readonly IStatisticService _statisticService;

		public StatisticsController(IStatisticService statisticService)
		{
			_statisticService = statisticService;
		}

		[HttpGet("GetBrandCount")]
		public async Task<IActionResult> GetBrandCount()
		{
			return Ok(await _statisticService.GetBrandCount());
		}

		[HttpGet("GetCategoryCount")]
		public async Task<IActionResult> GetCategoryCount()
		{
			return Ok(await _statisticService.GetCategoryCount());
		}

		[HttpGet("GetContactCount")]
		public async Task<IActionResult> GetContactCount()
		{
			return Ok(await _statisticService.GetContactCount());
		}

		[HttpGet("GetAvgProductPrice")]
		public async Task<IActionResult> GetAvgProductPrice()
		{
			return Ok(await _statisticService.GetAvgProductPrice());
		}

		[HttpGet("GetLastCreatedProductName")]
		public async Task<IActionResult> GetLastCreatedProductName()
		{
			return Ok(await _statisticService.GetLastCreatedProductName());
		}
	}
}
