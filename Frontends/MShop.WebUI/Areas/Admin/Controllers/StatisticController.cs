using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.StatisticServices;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class StatisticController : Controller
	{
		private readonly IStatisticService _statisticService;

		public StatisticController(IStatisticService statisticService)
		{
			_statisticService = statisticService;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.CategoryCount=await _statisticService.GetCategoryCount();
			ViewBag.BrandCount=await _statisticService.GetBrandCount();
			ViewBag.ProductAvg=await _statisticService.GetAvgProductPrice();
			ViewBag.LastCreatedProduct=await _statisticService.GetLastCreatedProductName();

			return View();
		}
	}
}
