using M.Shop.Catalog.Dtos.FeatureSliderDtos;
using M.Shop.Catalog.Services.FeatureSliderServices;
using M.Shop.Catalog.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureSlidersController : ControllerBase
	{
		private readonly IFeatureSliderService _featureSliderService;

		public FeatureSlidersController(IFeatureSliderService featureSliderService)
		{
			_featureSliderService = featureSliderService;
		}

		[HttpGet]
		public async Task<IActionResult> FeatureSliderList()
		{
			return Ok(await _featureSliderService.GetAllFeatureSlidersAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetFeatureSliderById(string id)
		{
			return Ok(await _featureSliderService.GetFeatureSliderByIdAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
		{
			await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult>UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task <IActionResult>DeleteFeatureSlider(string id)
		{
			await _featureSliderService.DeleteFeatureSliderAsync(id);
			return Ok("Silme Başarılı");
		}

	}
}
