using Frontends.DTO.MESSAGE;

namespace MShop.WebUI.Services.MessageServices
{
	public interface IUserMessageService
	{
		
		Task<GetMessageByUserId> GetMessageByUserId(string userId);
		Task SendMessage(CreateMessageDto createMessageDto);
		Task ReadedMessage(int messageId);
		Task DeleteMessage(int messageId);
	}
}
