using AutoMapper;
using MShop.Message.DTOS;
using MShop.Message.Entities;

namespace MShop.Message.Mapping
{
	public class GeneralMapping:Profile
	{
		public GeneralMapping()
		{
			CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
			CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
			CreateMap<UserMessage, GetMessageByUserId>().ReverseMap();
			CreateMap<UserMessage, GetMessageDetailByMessageIdDto>().ReverseMap();
		}
	}
}
