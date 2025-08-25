using Cargo.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.WebApi.Controllers
{
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
			return Ok(await _companyService.TGetListAll());
		}

		
	}
}
