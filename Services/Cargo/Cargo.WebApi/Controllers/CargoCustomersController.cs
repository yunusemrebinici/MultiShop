using Cargo.BusinessLayer.Abstract;
using Cargo.DTO.CargoCustomerDtos;
using Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCustomersController : ControllerBase
	{
		private readonly ICargoCustomerService _customerService;

		public CargoCustomersController(ICargoCustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetUserCargoDetail(string userId)
		{

			var values = await _customerService.TGetUserCargoDetail(userId);

			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult>AddUserCargoDetail(CreateCargoCustomerDto createCargoCustomerDto)
		{
			
			await _customerService.CreateCargoDetail(createCargoCustomerDto);
			return Ok("Ekleme Başarılı");
		}
	}
}
