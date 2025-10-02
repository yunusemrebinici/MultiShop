using Frontends.DTO.BASKET;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.BasketServices;
using MShop.WebUI.Services.CatalogServices.ProductServices;

namespace MShop.WebUI.Controllers
{
	public class ShoppingCardController : Controller
	{
		private readonly IBasketService _basketService;
		private readonly IProductService _productService;

		public ShoppingCardController(IBasketService basketService, IProductService productService)
		{
			_basketService = basketService;
			_productService = productService;
		}

		public async Task<IActionResult> Index()
		{
			
			return View();
		}

		public async Task<IActionResult> AddBasketItem(string id)
		{
			var values = await _productService.GetByIdProductAsync(id);
			var Items = new BasketItemDto()
			{
				ProductId = values.ProductID,
				ProductName = values.ProductName,
				Price = values.ProductPrice,
				ProductImageUrl = values.ProductImageUrl,
				Quantity = 1
			};
			await _basketService.AddBasketItem(Items);
			return RedirectToAction("Index", "ProductList");

		}

		public async Task<IActionResult>RemoveBasketItem(string id)
		{
			await _basketService.RemoveBasketItem(id);
			return RedirectToAction("Index");
		}
	}
}
