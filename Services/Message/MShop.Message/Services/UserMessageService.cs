using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MShop.Message.Context;
using MShop.Message.DTOS;
using MShop.Message.Entities;

namespace MShop.Message.Services
{
	public class UserMessageService : IUserMessageService
	{
		private readonly MessageContext _messageContext;
		private readonly IMapper _mapper;

		public UserMessageService(MessageContext messageContext, IMapper mapper)
		{
			_messageContext = messageContext;
			_mapper = mapper;
		}

		public async Task<List<ResultMessageDto>> AllMessage()
		{
			var values = await _messageContext.Messages.ToListAsync();
			return _mapper.Map<List<ResultMessageDto>>(values);
		}

		public async Task DeleteMessage(int messageId)
		{
			var remove = await _messageContext.Messages.Where(x=>x.UserMessageId==messageId).FirstOrDefaultAsync();
			 _messageContext.Messages.Remove(remove);
			await _messageContext.SaveChangesAsync();
		}

		public async Task<List<GetMessageByUserId>> GetMessageByUserId(string userId)
		{
			var values= await _messageContext.Messages.Where(x => x.ReceiverId == userId).ToListAsync();
			return _mapper.Map<List<GetMessageByUserId>>(values);
		}

		public async Task<GetMessageDetailByMessageIdDto> GetMessageDetailByMessageId(int messageId)
		{
			var value= await _messageContext.Messages.Where(x=>x.UserMessageId == messageId).FirstOrDefaultAsync();
			return  _mapper.Map<GetMessageDetailByMessageIdDto>(value);
		}

		public async Task ReadedMessage(int messageId)
		{
			var update = await _messageContext.Messages.Where(x => x.UserMessageId == messageId).FirstOrDefaultAsync();
			update.IsReaded=true;
			_messageContext.Messages.Update(update);
			await _messageContext.SaveChangesAsync();
		}

		public async Task SendMessage(CreateMessageDto createMessageDto)
		{
			createMessageDto.IsReaded = false;
			var values = _mapper.Map<UserMessage>(createMessageDto);
			 _messageContext.Messages.AddAsync(values);
			await _messageContext.SaveChangesAsync();
		}
	}
}
