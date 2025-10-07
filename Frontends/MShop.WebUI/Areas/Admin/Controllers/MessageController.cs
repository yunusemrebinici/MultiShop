using Frontends.DTO.MESSAGE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MShop.WebUI.Services.MessageServices;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class MessageController : Controller
	{
		private readonly IUserMessageService _messageService;

		public MessageController(IUserMessageService messageService)
		{
			_messageService = messageService;
		}

		public async Task<IActionResult> InBox()
		{
			var response = await _messageService.GetMessageByUserId();
			return View(response);
		}

		[HttpGet("{UserMessageId}")]
		public async Task<IActionResult> MessageDetail(int UserMessageId)
		{
			return View();
		}

		public async Task<IActionResult> DeleteMessage(int UserMessageId)
		{
			return RedirectToAction("InBox");
		}

		[HttpGet]
		public async Task<IActionResult> SendMessage()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
		{
			return RedirectToAction("InBox");
		}
	}
}
