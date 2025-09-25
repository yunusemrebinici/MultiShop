using Frontends.DTO.CATALOG.FeatureSliderDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class FeatureSliderController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IFeatureSliderService _featureSliderService;


		public FeatureSliderController(IHttpClientFactory httpClientFactory, IFeatureSliderService featureSliderService)
		{
			_httpClientFactory = httpClientFactory;
			_featureSliderService = featureSliderService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _featureSliderService.GetAllFeatureSlidersAsync();
			return View(values);
		}


		[HttpGet]
		public async Task<IActionResult> CreateFeatureSlider()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
		{

			await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
			return RedirectToAction("Index");

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateFeatureSlider(string id)
		{
			var values = await _featureSliderService.GetFeatureSliderByIdAsync(id);
			return View(new UpdateFeatureSliderDto()
			{
				Description = values.Description,
				Featured = values.Featured,
				FeatureSliderId = values.FeatureSliderId,

			});
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);

			return RedirectToAction("Index");

		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteFeatureSlider(string id)
		{

			await _featureSliderService.DeleteFeatureSliderAsync(id);
			return RedirectToAction("Index");

		}
	}
}

