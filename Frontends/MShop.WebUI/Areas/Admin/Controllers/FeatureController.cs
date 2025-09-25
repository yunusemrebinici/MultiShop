using Frontends.DTO.CATALOG.FeatureDTOS;
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
	public class FeatureController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IFeatureService _featureService;

		public FeatureController(IHttpClientFactory httpClientFactory, IFeatureService featureService)
		{
			_httpClientFactory = httpClientFactory;
			_featureService = featureService;
		}

		public async Task<IActionResult> Index()
		{
		    var values = await _featureService.GettAllFeatureAsync();
			return View(values);
		}


		[HttpGet]
		public async Task<IActionResult> CreateFeature()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			await _featureService.CreateFeatureAsync(createFeatureDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateFeature(string id)
		{
			var values = await _featureService.GetByIdFeatureAsync(id);

			return View(new UpdateFeatureDto()
			{
				FeatureId = values.FeatureId,
				Icon=values.Icon,
				Title=values.Title,
			});
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			await _featureService.UpdateFeatureAsync(updateFeatureDto);

			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteFeature(string id)
		{
			await _featureService.DeleteFeatureAsync(id);
			return RedirectToAction("Index");
		}
	}
}
