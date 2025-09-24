using Frontends.DTO.CATALOG.OfferDiscountDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class OfferDiscountController : Controller
	{
		
		private readonly IOfferDiscountService _offerDiscountService;

		public OfferDiscountController(IOfferDiscountService offerDiscountService)
		{
			_offerDiscountService = offerDiscountService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await	_offerDiscountService.GettAllOfferDiscountAsync();
			ViewBag.count = values.Count;
			return View(values);
			
		}


		[HttpGet]
		public async Task<IActionResult> CreateOfferDiscount()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
		{
			await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateOfferDiscount(string id)
		{
			var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
			return View(new UpdateOfferDiscountDto()
			{
				ImageUrl=values.ImageUrl,
				OfferDiscountId=values.OfferDiscountId,
				SubTitle=values.SubTitle,
				Title=values.Title,
				
			});
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteOfferDiscount(string id)
		{
			await _offerDiscountService.DeleteOfferDiscountAsync(id);
			return RedirectToAction("Index");
		}
	}
}
