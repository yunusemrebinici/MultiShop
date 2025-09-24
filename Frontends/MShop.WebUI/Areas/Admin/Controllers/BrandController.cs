using Frontends.DTO.CATALOG.BrandDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Text;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	[Route("/Admin/[Controller]/[Action]")]
	public class BrandController : Controller
	{
		private readonly IBrandService _brandService;

		public BrandController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		public async Task<IActionResult> Index()
		{

			var values = await _brandService.GettAllBrandAsync();
			return View(values);
		}


		[HttpGet]
		public async Task<IActionResult> CreateBrand()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
		{
             await _brandService.CreateBrandAsync(createBrandDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> UpdateBrand(string id)
		{
		    var values = await _brandService.GetByIdBrandAsync(id);
			return View(new UpdateBrandDto()
			{
				BrandId=values.BrandId,
				ImageUrl=values.ImageUrl,
				
			});
		}

		[HttpPost("{id}")]
		public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
		{
			await _brandService.UpdateBrandAsync(updateBrandDto);
			return RedirectToAction("Index");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteBrand(string id)
		{
			await _brandService.DeleteBrandAsync(id);
			return RedirectToAction("Index");
		}
	}
}
