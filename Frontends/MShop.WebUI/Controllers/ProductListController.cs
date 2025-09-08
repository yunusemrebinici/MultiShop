using Microsoft.AspNetCore.Mvc;

namespace MShop.WebUI.Controllers
{
	public class ProductListController : Controller
	{
		public async Task <IActionResult> Index()
		{
			return View();
		}

		public async Task<IActionResult> ProductDetail(string id)
		{
			ViewBag.ProductId=id;
			return View();
		}

		public async Task<IActionResult> ProductListWithCategoryId(string id) 
		{

			ViewBag.Id = id;
			return View();


		}

	}
}
