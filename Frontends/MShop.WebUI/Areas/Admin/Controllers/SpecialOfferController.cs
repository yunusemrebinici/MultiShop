using Frontends.DTO.CATALOG.SpecialOfferDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{

	[Authorize]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class SpecialOfferController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ISpecialOfferService _specialOfferService;

		public SpecialOfferController(IHttpClientFactory httpClientFactory, ISpecialOfferService specialOfferService)
		{
			_httpClientFactory = httpClientFactory;
			_specialOfferService = specialOfferService;
		}

		public async Task<IActionResult> Index()
		{
		    var values= await _specialOfferService.GettAllSpecialOfferAsync();
			return View(values);
		}


		[HttpGet]
		public async Task<IActionResult> CreateSpecialOffer()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
		{
			await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateSpecialOffer(string id)
		{
			var value=await _specialOfferService.GetByIdSpecialOfferAsync(id);
			return View(new UpdateSpecialOfferDto()
			{
				ImageUrl=value.ImageUrl,
				SpecialOfferId=value.SpecialOfferId,
				SubTitle=value.SubTitle,
				Title = value.Title
				
			});
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteSpecialOffer(string id)
		{
			await _specialOfferService.DeleteSpecialOfferAsync(id);
			return RedirectToAction("Index");
		}
	}
}


