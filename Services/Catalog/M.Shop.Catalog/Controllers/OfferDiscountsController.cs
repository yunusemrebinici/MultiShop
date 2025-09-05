using M.Shop.Catalog.Dtos.OfferDiscountDtos;
using M.Shop.Catalog.Services.OfferDiscountServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OfferDiscountsController : ControllerBase
	{
		private readonly IOfferDiscountServices _offerDiscountService;

		public OfferDiscountsController(IOfferDiscountServices offerDiscountService)
		{
			_offerDiscountService = offerDiscountService;
		}

		[HttpGet]
		public async Task<IActionResult> OfferDiscountList()
		{
			return Ok(await _offerDiscountService.GettAllOfferDiscountAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOfferDiscountById(string id)
		{
			return Ok(await _offerDiscountService.GetByIdOfferDiscountAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto offerDiscountDto)
		{
			await _offerDiscountService.CreateOfferDiscountAsync(offerDiscountDto);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto offerDiscountDto)
		{
			await _offerDiscountService.UpdateOfferDiscountAsync(offerDiscountDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOfferDiscount(string id)
		{
			await _offerDiscountService.DeleteOfferDiscountAsync(id);
			return Ok("Silme Başarılı");
		}
	}
}
