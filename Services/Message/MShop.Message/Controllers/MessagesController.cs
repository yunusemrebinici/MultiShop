using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MShop.Message.DTOS;
using MShop.Message.Services;

namespace MShop.Message.Controllers
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
	   private readonly IUserMessageService _userMessageService;

		public MessagesController(IUserMessageService userMessageService)
		{
			_userMessageService = userMessageService;
		}

		[HttpGet]
		public async Task<IActionResult> AllMessage()
		{
			return Ok(await _userMessageService.AllMessage());
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetMessageByUserId(string userId)
		{
			return Ok(await _userMessageService.GetMessageByUserId(userId));
		}

		[HttpPost]
		public async Task<IActionResult>SendMessage(CreateMessageDto createMessageDto)
		{
			await _userMessageService.SendMessage(createMessageDto);
			return Ok("Ekleme İşlemi Başarılı");
		}

		[HttpPut("ReadedMessage/{messageId}")]
		public async Task<IActionResult> ReadedMessage(int messageId)
		{
			await _userMessageService.ReadedMessage(messageId);
			return Ok("Okundu İşlemi Gerçekleştirildi");
		}

		[HttpDelete("DeleteMessage/{messageId}")]
		public async Task<IActionResult>DeleteMessage(int messageId)
		{
			await _userMessageService.DeleteMessage(messageId);
			return Ok("Silme İşlemi Başarılı");
		}
	}
}
