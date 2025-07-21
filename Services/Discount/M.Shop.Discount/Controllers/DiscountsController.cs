using M.Shop.Discount.Context;
using M.Shop.Discount.Dtos;
using M.Shop.Discount.Entitites;
using M.Shop.Discount.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M.Shop.Discount.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountsController : ControllerBase
	{
		private readonly IDiscountService _discountService;

		public DiscountsController(IDiscountService discountService)
		{
			_discountService = discountService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCoupon()
		{
			return Ok(await _discountService.GettAllCouponAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCouponById(int id)
		{
			return Ok(await _discountService.GettCouponByIdAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateCoupon(CreateCouponDto couponDto)
		{
			await _discountService.CreateCouponAsync(couponDto);

			return Ok("Ekleme Başarılı");
		}
		[HttpPut]
		public async Task<IActionResult> UpdateCoupon(UpdateCouponDto couponDto)
		{
			await _discountService.UpdateCouponAsync(couponDto);
			return Ok("Güncelleme İşlemi Başarılı");

		}
		[HttpDelete("{id}")]
		public async Task<IActionResult>DeleteCoupon(int id)
		{
			await _discountService.DeleteCouponAsync(id);
			return Ok("Silme İşlemi Başarılı");
		}
	}
}
