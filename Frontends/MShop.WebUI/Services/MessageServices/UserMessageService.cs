using Frontends.DTO.MESSAGE;
using MShop.WebUI.Services.Interfaces;

namespace MShop.WebUI.Services.MessageServices
{
	public class UserMessageService : IUserMessageService
	{
		private readonly HttpClient _httpClient;
		private readonly IUserService _userService;

		public UserMessageService(HttpClient httpClient, IUserService userService)
		{
			_httpClient = httpClient;
			_userService = userService;
		}

		public async Task DeleteMessage(int messageId)
		{
			await _httpClient.DeleteAsync($"Messages/DeleteMessage/{messageId}");
		}

		public async Task<List<GetMessageByUserId>> GetMessageByUserId()
		{
			string userId = _userService.GetUserInfo().Result.Id;
			var response = await _httpClient.GetFromJsonAsync<List<GetMessageByUserId>>($"Messages/{userId}");

			return response;
		}

		public async Task<GetMessageDetailByMessageIdDto> GetMessageDetailByMessageId(int messageId)
		{
			
			var response = await _httpClient.GetFromJsonAsync<GetMessageDetailByMessageIdDto>($"Messages/GetMessageDetail/{messageId}");
			return response;
		}

		public async Task<List<GetMessageWithSenderNameDto>> GetMessageWithSenderName()
		{
			var allUsers = await _userService.GetAllUsers();
			var allmessage = GetMessageByUserId();
			List<GetMessageWithSenderNameDto> list = new List<GetMessageWithSenderNameDto>();
			
			foreach (var message in allmessage.Result)
			{

				for (int i = 0; i < allUsers.Count; i++)
				{
					if (allUsers[i].Id == message.SenderId)
					{
						GetMessageWithSenderNameDto value = new GetMessageWithSenderNameDto();
						value.SendedDate = message.SendedDate;
						value.SenderName = allUsers[i].Name;
						value.Subject = message.Subject;
						value.UserMessageId = message.UserMessageId;
						value.ReceiverId = message.ReceiverId;
						value.IsReaded = message.IsReaded;
						value.Messages = message.Messages;

						list.Add(value);
					}
				}


			}
			return list;



		}

		public async Task ReadedMessage(int messageId)
		{
			await _httpClient.GetAsync($"Messages/ReadedMessage/{messageId}");
		}

		public async Task SendMessage(CreateMessageDto createMessageDto)
		{
			createMessageDto.SenderId = _userService.GetUserInfo().Result.Id;
			await _httpClient.PostAsJsonAsync<CreateMessageDto>("Messages", createMessageDto);
		}
	}
}
