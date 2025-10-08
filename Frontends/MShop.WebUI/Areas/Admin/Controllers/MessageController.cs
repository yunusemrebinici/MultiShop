using Frontends.DTO.MESSAGE;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MShop.WebUI.Services.Interfaces;
using MShop.WebUI.Services.MessageServices;

namespace MShop.WebUI.Areas.Admin.Controllers
{
	[Authorize]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]")]
	public class MessageController : Controller
	{
		private readonly IUserMessageService _messageService;
		private readonly IUserService _userService;

		public MessageController(IUserMessageService messageService, IUserService userService)
		{
			_messageService = messageService;
			_userService = userService;
		}

		public async Task<IActionResult> InBox()
		{
			var response = await _messageService.GetMessageWithSenderName();
			
			return View(response);
		}

		[HttpGet("{messageId}")]
		public async Task<IActionResult> MessageDetail(int messageId)
		{
			var response = await _messageService.GetMessageDetailByMessageId(messageId);
			await _messageService.ReadedMessage(messageId);
			return View(response);
		}

		[HttpGet("{UserMessageId}")]
		public async Task<IActionResult> DeleteMessage(int UserMessageId)
		{
			await _messageService.DeleteMessage(UserMessageId);
			return RedirectToAction("InBox");
		}

		[HttpGet]
		public async Task<IActionResult> SendMessage()
		{
			var allUsers= _userService.GetAllUsers();
			List<SelectListItem>UsersName=(from x in allUsers.Result
										   select new SelectListItem()
										   {
											   Value = x.Id,
											   Text = x.Name,
											  
										   }
										   ).ToList();
			ViewBag.Receiver = UsersName;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
		{

			await _messageService.SendMessage(createMessageDto);
			return RedirectToAction("InBox");
		}
	}
}
