using Frontends.DTO.CATALOG.FeatureDTOS;
using Frontends.DTO.CATALOG.FeatureProductDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.FeatureProductServices;
using MShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class FeatureProductController : Controller
	{
	
		private readonly IFeatureProductService _featureProductService;

		public FeatureProductController(IFeatureProductService featureProductService)
		{
			_featureProductService = featureProductService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _featureProductService.GettAllFeatureProductAsync();
			return View(values);
		}


		[HttpGet]
		public async Task<IActionResult> CreateFeatureProduct()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeatureProduct(CreateFeatureProductDto createFeatureProductDto)
		{

			await _featureProductService.CreateFeatureProductAsync(createFeatureProductDto);
			return RedirectToAction("Index");

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateFeatureProduct(string id)
		{
			var value= await _featureProductService.GetByIdFeatureProductAsync(id);

			return View(new UpdateFeatureProductDto()
			{
				Title = value.Title,
				FeatureProductId=value.FeatureProductId,
				ImageUrl=value.ImageUrl,
				Price=value.Price,		
			});
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateFeatureProduct(UpdateFeatureProductDto updateFeatureProductDto)
		{
			await _featureProductService.UpdateFeatureProductAsync(updateFeatureProductDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteFeatureProduct(string id)
		{
			await _featureProductService.DeleteFeatureProductAsync(id);
			return RedirectToAction("Index");
		}
	}
}
