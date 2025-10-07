using Frontends.DTO.MESSAGE;

namespace MShop.WebUI.Services.MessageServices
{
	public interface IUserMessageService
	{
		Task<GetMessageDetailByMessageIdDto> GetMessageDetailByMessageId(int messageId);
		Task<List<GetMessageByUserId>> GetMessageByUserId();
		Task<List<GetMessageWithSenderNameDto>> GetMessageWithSenderName();
		Task SendMessage(CreateMessageDto createMessageDto);
		Task ReadedMessage(int messageId);
		Task DeleteMessage(int messageId);
	}
}
