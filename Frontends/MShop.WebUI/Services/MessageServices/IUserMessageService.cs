using Frontends.DTO.MESSAGE;

namespace MShop.WebUI.Services.MessageServices
{
	public interface IUserMessageService
	{
		
		Task<List<GetMessageByUserId>> GetMessageByUserId();
		Task SendMessage(CreateMessageDto createMessageDto);
		Task ReadedMessage(int messageId);
		Task DeleteMessage(int messageId);
	}
}
