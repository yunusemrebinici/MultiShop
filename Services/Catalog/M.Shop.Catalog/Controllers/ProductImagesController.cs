using M.Shop.Catalog.Dtos.ProductImageDtos;
using M.Shop.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductImagesController : ControllerBase
	{
		private readonly IProductImageServices _ProductImageService;

		public ProductImagesController(IProductImageServices ProductImageService)
		{
			_ProductImageService = ProductImageService;
		}

		[HttpGet]
		public async Task<IActionResult> ProductImageList()
		{
			return Ok(await _ProductImageService.GettAllProductImageAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductImageById(string id)
		{
			return Ok(await _ProductImageService.GetByIdProductImageAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateProductImage(CreateProductImageDto ProductImageDto)
		{
			await _ProductImageService.CreateProductImageAsync(ProductImageDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto ProductImageDto)
		{
			await _ProductImageService.UpdateProductImageAsync(ProductImageDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProductImage(string id)
		{
			await _ProductImageService.DeleteProductImageAsync(id);
			return Ok("Silme Başarılı");
		}
	}
}
