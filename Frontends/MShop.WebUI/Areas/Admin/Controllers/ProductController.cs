
using Frontends.DTO.CATALOG.CategoryDTOS;
using Frontends.DTO.CATALOG.ProductDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MShop.WebUI.Services.CatalogServices.CategoryServices;
using MShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;
namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;

		public ProductController(IHttpClientFactory httpClientFactory, ICategoryService categoryService, IProductService productService)
		{
			_httpClientFactory = httpClientFactory;
			_categoryService = categoryService;
			_productService = productService;
		}
		internal async Task<List<SelectListItem>> CategorySelectListItem()
		{
			
				
				var values = await _categoryService.GettAllCategoryAsync();
				List<SelectListItem> selectListItems = (from x in values
								   select new SelectListItem
								   {
									   Text = x.CategoryName,
									   Value = x.CategoryID
								   }).ToList();

				return selectListItems;
			
			
		}


		public async Task<IActionResult> Index()
		{
			var values=await _productService.GetAllProductWithCategoryNameAsync();
			return View(values);
		}

		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			
			ViewBag.CategoryNameList = CategorySelectListItem().Result;
			
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto) 
		{
			await _productService.CreateProductAsync(createProductDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateProduct(string id)
		{
			var values= await _productService.GetByIdProductAsync(id);
			ViewBag.CategoryNameListForUpdate = CategorySelectListItem().Result;
			return View(new UpdateProductDto()
			{
				ProductDescription = values.ProductDescription,
				CategoryID = values.CategoryID,
				ProductID = values.ProductID,
				ProductImageUrl = values.ProductImageUrl,
				ProductName = values.ProductName,
				ProductPrice= values.ProductPrice,
				
			});
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto) 
		{
			await _productService.UpdateProductAsync(updateProductDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			await _productService.DeleteProductAsync(id);
			return RedirectToAction("Index");
		}
	}
}