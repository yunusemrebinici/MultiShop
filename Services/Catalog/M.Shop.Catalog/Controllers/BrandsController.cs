using M.Shop.Catalog.Dtos.BrandDtos;
using M.Shop.Catalog.Services.BrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		private readonly IBrandServices _brandService;

		public BrandsController(IBrandServices brandService)
		{
			_brandService = brandService;
		}

		[HttpGet]
		public async Task<IActionResult> BrandList()
		{
			return Ok(await _brandService.GettAllBrandAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBrandById(string id)
		{
			return Ok(await _brandService.GetByIdBrandAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandDto brandDto)
		{
			await _brandService.CreateBrandAsync(brandDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateBrand(UpdateBrandDto brandDto)
		{
			await _brandService.UpdateBrandAsync(brandDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBrand(string id)
		{
			await _brandService.DeleteBrandAsync(id);
			return Ok("Silme Başarılı");
		}
	}
}
