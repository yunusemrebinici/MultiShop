using Frontends.DTO.MESSAGE;

namespace MShop.WebUI.Services.MessageServices
{
	public class UserMessageService : IUserMessageService
	{
		private readonly HttpClient _httpClient;

		public UserMessageService(HttpClient httpClient)
		{
		    _httpClient = httpClient;
		}

		public async Task DeleteMessage(int messageId)
		{
			await _httpClient.DeleteAsync($"messages/DeleteMessage/{messageId}");
		}

		public Task<GetMessageByUserId> GetMessageByUserId(string userId)
		{
			throw new NotImplementedException();
		}

		public Task ReadedMessage(int messageId)
		{
			throw new NotImplementedException();
		}

		public Task SendMessage(CreateMessageDto createMessageDto)
		{
			throw new NotImplementedException();
		}
	}
}
