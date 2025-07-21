using M.Shop.Catalog.Dtos.ProductDtos;
using M.Shop.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductServices _ProductService;

		public ProductsController(IProductServices ProductService)
		{
			_ProductService = ProductService;
		}

		[HttpGet]
		public async Task<IActionResult> ProductList()
		{
			return Ok(await _ProductService.GettAllProductAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(string id)
		{
			return Ok(await _ProductService.GetByIdProductAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto ProductDto)
		{
			await _ProductService.CreateProductAsync(ProductDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto ProductDto)
		{
			await _ProductService.UpdateProductAsync(ProductDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			await _ProductService.DeleteProductAsync(id);
			return Ok("Silme Başarılı");
		}

	}

}
