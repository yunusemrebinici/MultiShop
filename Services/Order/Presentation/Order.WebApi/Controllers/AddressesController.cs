
using Application.Features.CQRS.Commands.AddressComands;
using Application.Features.CQRS.Handlers.AddressHandlers;
using Application.Features.CQRS.Quaries.AddressQuaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AddressesController : ControllerBase
	{
		private readonly CreateAddressCommandHandler _createAddressCommandHandler;
		private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
		private readonly GetAddressQueryHandle _getAddressQueryHandle;
		private readonly RemoveAddressCommandHandle _removeAddressCommandHandler;
		private readonly UpdateAddressCommandHandle _updateAddressCommandHandler;

		public AddressesController(CreateAddressCommandHandler createAddressCommandHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, GetAddressQueryHandle getAddressQueryHandle, RemoveAddressCommandHandle removeAddressCommandHandler, UpdateAddressCommandHandle updateAddressCommandHandler)
		{
			_createAddressCommandHandler = createAddressCommandHandler;
			_getAddressByIdQueryHandler = getAddressByIdQueryHandler;
			_getAddressQueryHandle = getAddressQueryHandle;
			_removeAddressCommandHandler = removeAddressCommandHandler;
			_updateAddressCommandHandler = updateAddressCommandHandler;
		}

		[HttpPost]
		public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
		{
			await _createAddressCommandHandler.Handle(command);
			return Ok("Ekleme Başarılı");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAddress(int id)
		{
			GetAddressByIdQuery query = new GetAddressByIdQuery(id);
			return Ok(await _getAddressByIdQueryHandler.Handle(query));
		}

		[HttpGet]
		public async Task<IActionResult> AddressList()
		{
			return Ok(await _getAddressQueryHandle.Handle());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult>RemoveAddress(int id)
		{
			RemoveAddressCommand removeAddressCommand=new RemoveAddressCommand(id);
			await _removeAddressCommandHandler.Handle(removeAddressCommand);
			return Ok("Silme İşlemi Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult>UpdateAddress(UpdateAddressCommand updateAddressCommand)
		{
			await _updateAddressCommandHandler.Handle(updateAddressCommand);
			return Ok("Güncelleme Başarılı");
		}
		


	}
}
