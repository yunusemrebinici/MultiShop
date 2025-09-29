using Basket.WebApi.Dtos;
using Basket.WebApi.LoginServices;
using Basket.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class BasketsController : ControllerBase
	{
		private readonly IBasketService _basketService;
		private readonly ILoginService _loginService;

		public BasketsController(IBasketService basketService, ILoginService loginService)
		{
			_basketService = basketService;
			_loginService = loginService;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetBasketDetail(string id)
		{
			var user = User.Claims;
			var deneme = _loginService.GetUserId;
			var values = await _basketService.GetBasket(id);
			if (values != null)
			{
				return Ok(values);
			}
			return Ok("Sepet Boş");
		}

		[HttpPost]
		public async Task<IActionResult>SaveMyBasket(BasketTotalDto basketTotalDto)
		{
			basketTotalDto.UserId = _loginService.GetUserId;
			await _basketService.SaveBasket(basketTotalDto);
			return Ok("Sepetteki değişikler kaydedildi.");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteBasket()
		{
			await _basketService.DeleteBasket(_loginService.GetUserId);
			return Ok("Sepet Başarıyla Silindi");
		}
	}
}
