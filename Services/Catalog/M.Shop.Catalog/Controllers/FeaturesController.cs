using M.Shop.Catalog.Dtos.FeatureDtos;
using M.Shop.Catalog.Services.FeatureServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Catalog.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly IFeatureServices _FeatureService;

		public FeaturesController(IFeatureServices featureService)
		{
			_FeatureService = featureService;
		}

		[HttpGet]
		public async Task<IActionResult> FeatureList()
		{
			return Ok(await _FeatureService.GettAllFeatureAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetFeatureById(string id)
		{
			return Ok(await _FeatureService.GetByIdFeatureAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto featureDto)
		{
			await _FeatureService.CreateFeatureAsync(featureDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto featureDto)
		{
			await _FeatureService.UpdateFeatureAsync(featureDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteFeature(string id)
		{
			await _FeatureService.DeleteFeatureAsync(id);
			return Ok("Silme Başarılı");
		}
	}
}
