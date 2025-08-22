
using Application.Features.CQRS.Commands.OrderDetailCommands;
using Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Application.Features.CQRS.Quaries.OrderDetailQuaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly CreateOrderDetailCommandHandle _createOrderDetailCommandHandler;
		private readonly GetOrderDetailByIdQueryHandle _getOrderDetailByIdQueryHandler;
		private readonly GetOrderDetailQueryHandle _getOrderDetailQueryHandle;
		private readonly RemoveOrderDetailCommandHandle _removeOrderDetailCommandHandler;
		private readonly UpdateOrderDetailCommandHandle _updateOrderDetailCommandHandler;

		public OrderDetailsController(CreateOrderDetailCommandHandle createOrderDetailCommandHandler, GetOrderDetailByIdQueryHandle getOrderDetailByIdQueryHandler, GetOrderDetailQueryHandle getOrderDetailQueryHandle, RemoveOrderDetailCommandHandle removeOrderDetailCommandHandler, UpdateOrderDetailCommandHandle updateOrderDetailCommandHandler)
		{
			_createOrderDetailCommandHandler = createOrderDetailCommandHandler;
			_getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
			_getOrderDetailQueryHandle = getOrderDetailQueryHandle;
			_removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
			_updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
		}

		[HttpPost]
		public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
		{
			await _createOrderDetailCommandHandler.Handle(command);
			return Ok("Ekleme Başarılı");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetOrderDetail(int id)
		{
			return Ok(await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id)));
		}

		[HttpGet]
		public async Task<IActionResult> OrderDetailList()
		{
			return Ok(await _getOrderDetailQueryHandle.Handle());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveOrderDetail(int id)
		{
			await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand (id));
			return Ok("Silme İşlemi Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
		{
			await _updateOrderDetailCommandHandler.Handle(updateOrderDetailCommand);
			return Ok("Güncelleme Başarılı");
		}

	}
}
