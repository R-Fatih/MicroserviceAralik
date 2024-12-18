using MicroserviceAralık.Message.Dtos;

namespace MicroserviceAralık.Message.Services.MessageServices;

public interface IMessageService
{
    Task<CreateMessageDto> CreateMessage(CreateMessageDto dto);
    Task<List<ResultMessageDto>> GetAllMessages();
    Task UpdateMessage(ResultMessageDto dto);
    Task<List<ResultMessageDto>> GetInbox(string receiverId);
    Task<List<ResultMessageDto>> GetSendBox(string senderId);
    Task<ResultMessageDto> GetMessageById(int id);
}
