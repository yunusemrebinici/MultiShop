using M.Shop.Catalog.Dtos.SpecialOfferDtos;
using M.Shop.Catalog.Services.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class SpecialOffersController : ControllerBase
	{
		private readonly ISpecialOfferServices _SpecialOfferService;

		public SpecialOffersController(ISpecialOfferServices specialOfferService)
		{
			_SpecialOfferService = specialOfferService;
		}

		[HttpGet]
		public async Task<IActionResult> SpecialOfferList()
		{
			return Ok(await _SpecialOfferService.GettAllSpecialOfferAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetSpecialOfferById(string id)
		{
			return Ok(await _SpecialOfferService.GetByIdSpecialOfferAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto specialOfferDto)
		{
			await _SpecialOfferService.CreateSpecialOfferAsync(specialOfferDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto specialOfferDto)
		{
			await _SpecialOfferService.UpdateSpecialOfferAsync(specialOfferDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteSpecialOffer(string id)
		{
			await _SpecialOfferService.DeleteSpecialOfferAsync(id);
			return Ok("Silme Başarılı");
		}
	}
}
