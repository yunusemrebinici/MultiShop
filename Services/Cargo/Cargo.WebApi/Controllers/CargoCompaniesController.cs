using Cargo.BusinessLayer.Abstract;
using Cargo.DTO.CargoCompanyDtos;
using Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCompaniesController : ControllerBase
	{
		private readonly ICargoCompanyService _companyService;

		public CargoCompaniesController(ICargoCompanyService companyService)
		{
			_companyService = companyService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			List<ResultCargoCompanyDto> resultCargos = new List<ResultCargoCompanyDto>();
			var values = await _companyService.TGetListAll();
			foreach (var value in values)
			{
				resultCargos.Add(new ResultCargoCompanyDto
				{
					CargoCompanyId = value.CargoCompanyId,
					CargoCompanyName = value.CargoCompanyName,
				});

			}
			return Ok(resultCargos);
		}

		[HttpGet("id")]
		public async Task<IActionResult> GetByIdCargoCompany(int id)
		{
			var values = await _companyService.TGetById(id);
			ResultCargoCompanyDto resultCargo = new ResultCargoCompanyDto()
			{
				CargoCompanyId = values.CargoCompanyId,
				CargoCompanyName = values.CargoCompanyName,
			};
			return Ok(resultCargo);

		}

		[HttpPost]
		public async Task<IActionResult> AddCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
		{
			await _companyService.TAdd(new CargoCompany { CargoCompanyName = createCargoCompanyDto.CargoCompanyName });
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
		{
			await _companyService.TUpdate(new CargoCompany { CargoCompanyId = updateCargoCompanyDto.CargoCompanyId, CargoCompanyName = updateCargoCompanyDto.CargoCompanyName });
			return Ok("Güncelleme Başarılı");

		}

		[HttpDelete]
		public async Task<IActionResult>RemoveCargoCompany(int id)
		{
			var remove = await _companyService.TGetById(id);
			await _companyService.TDelete(remove);
			return Ok("Silme İşlemi Başarılı");
		}
	}
}
