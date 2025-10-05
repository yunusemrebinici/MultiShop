using Application.Features.CQRS.Commands.OrderDetailCommands;
using Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Application.Features.Mediator.Commands.OrderingCommands;
using Application.Features.Mediator.Quaries.OrderingQuaries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Order.WebApi.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class OrderingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public OrderingsController(IMediator mediator)
		{
			_mediator = mediator;
		}	

		[HttpGet]
		public async Task<IActionResult> OrderingList()
		{
			var values = await _mediator.Send(new GetOrderingQuery());
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult>GetOrdering(int id)
		{
			var value = await _mediator.Send(new GetOrderingByIdQuery(id));
			return Ok(value);
		}

		[HttpPost]
		public async Task<IActionResult>CreateOrdering(CreateOrderingCommand createOrderingCommand)
		{
			
			await _mediator.Send(createOrderingCommand);
			return Ok("Ekleme Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult>UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
		{
			await _mediator.Send(updateOrderingCommand);
			return Ok("Güncelleme Başarılı");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveOrdering(int id)
		{
			await _mediator.Send(new RemoveOrderingCommand(id));
			return Ok("Silme İşlemi Başarılı");
		}
	}
}
