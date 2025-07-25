﻿using M.Shop.Catalog.Dtos.ProductDetailDtos;
using M.Shop.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductDetailsController : ControllerBase
	{
		private readonly IProductDetailServices _ProductDetailService;

		public ProductDetailsController(IProductDetailServices ProductDetailService)
		{
			_ProductDetailService = ProductDetailService;
		}

		[HttpGet]
		public async Task<IActionResult> ProductDetailList()
		{
			return Ok(await _ProductDetailService.GettAllProductDetailAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductDetailById(string id)
		{
			return Ok(await _ProductDetailService.GetByIdProductDetailAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto ProductDetailDto)
		{
			await _ProductDetailService.CreateProductDetailAsync(ProductDetailDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto ProductDetailDto)
		{
			await _ProductDetailService.UpdateProductDetailAsync(ProductDetailDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProductDetail(string id)
		{
			await _ProductDetailService.DeleteProductDetailAsync(id);
			return Ok("Silme Başarılı");
		}
	}
}
