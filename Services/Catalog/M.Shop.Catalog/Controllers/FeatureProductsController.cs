using M.Shop.Catalog.Dtos.FeatureProductDtos;
using M.Shop.Catalog.Services.FeatureProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Catalog.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureProductsController : ControllerBase
	{
		private readonly IFeatureProductServices _FeatureProductService;

		public FeatureProductsController(IFeatureProductServices featureProductService)
		{
			_FeatureProductService = featureProductService;
		}

		[HttpGet]
		public async Task<IActionResult> FeatureProductList()
		{
			return Ok(await _FeatureProductService.GettAllFeatureProductAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetFeatureProductById(string id)
		{
			return Ok(await _FeatureProductService.GetByIdFeatureProductAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeatureProduct(CreateFeatureProductDto featureProductDto)
		{
			await _FeatureProductService.CreateFeatureProductAsync(featureProductDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateFeatureProduct(UpdateFeatureProductDto featureProductDto)
		{
			await _FeatureProductService.UpdateFeatureProductAsync(featureProductDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteFeatureProduct(string id)
		{
			await _FeatureProductService.DeleteFeatureProductAsync(id);
			return Ok("Silme Başarılı");
		}
	}
}
