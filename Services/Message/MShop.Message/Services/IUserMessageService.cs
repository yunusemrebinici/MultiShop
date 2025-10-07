using MShop.Message.DTOS;

namespace MShop.Message.Services
{
	public interface IUserMessageService
	{
		Task<List<ResultMessageDto>> AllMessage();
		Task<List<GetMessageByUserId>> GetMessageByUserId(string userId);
		Task SendMessage(CreateMessageDto createMessageDto);
		Task ReadedMessage(int messageId);
		Task DeleteMessage(int messageId);
	}
}
