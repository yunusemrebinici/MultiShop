using Frontends.DTO.CATALOG.FeatureDTOS;
using Frontends.DTO.CATALOG.FeatureProductDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
		private readonly IFeatureService _featureService;

		public FeatureProductController(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _featureService.GettAllFeatureAsync();
			return View(values);
		}


		[HttpGet]
		public async Task<IActionResult> CreateFeatureProduct()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeatureProduct(CreateFeatureDto createFeatureProductDto)
		{

			await _featureService.CreateFeatureAsync(createFeatureProductDto);
			return RedirectToAction("Index");

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateFeatureProduct(string id)
		{
			var value= await _featureService.GetByIdFeatureAsync(id);

			return View(new UpdateFeatureDto()
			{
				Title = value.Title,
				FeatureId = id,
				Icon=value.Icon,
					
			});
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateFeatureProduct(UpdateFeatureDto updateFeatureProductDto)
		{
			await _featureService.UpdateFeatureAsync(updateFeatureProductDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteFeatureProduct(string id)
		{
			await _featureService.DeleteFeatureAsync(id);
			return RedirectToAction("Index");
		}
	}
}
