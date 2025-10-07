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

		public async Task<List<GetMessageByUserId>> GetMessageByUserId( )
		{
			string userId = _userService.GetUserInfo().Result.Id;
			var response= await _httpClient.GetFromJsonAsync<List<GetMessageByUserId>>($"Messages/{userId}");
			return response;
		}

		public async Task ReadedMessage(int messageId)
		{
			await _httpClient.GetAsync($"Messages/DeleteMessage/{messageId}");
		}

		public async Task SendMessage(CreateMessageDto createMessageDto)
		{
			createMessageDto.SenderId=_userService.GetUserInfo().Result.Id;
			await _httpClient.PostAsJsonAsync<CreateMessageDto>("Messages", createMessageDto);
		}
	}
}
