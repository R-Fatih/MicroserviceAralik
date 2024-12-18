using AutoMapper;
using MicroserviceAralık.Message.Dal.Context;
using MicroserviceAralık.Message.Dal.Entities;
using MicroserviceAralık.Message.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Message.Services.MessageServices;

public class MessageService(IMapper _mapper, AppDbContext _context) : IMessageService
{
    public async Task<CreateMessageDto> CreateMessage(CreateMessageDto dto)
    {
        var mappedMessage = _mapper.Map<UserMessage>(dto);
        mappedMessage.Status = "Gönderildi";
        mappedMessage.SentDate = DateTime.UtcNow;
        await _context.UserMessages.AddAsync(mappedMessage);
        await _context.SaveChangesAsync();
        return dto;

    }

    public async Task<List<ResultMessageDto>> GetAllMessages()
    {
        var values = await _context.UserMessages.ToListAsync();
        var mappedValue = _mapper.Map<List<ResultMessageDto>>(values);
        return mappedValue;
    }

    public async Task<List<ResultMessageDto>> GetInbox(string receiverId)
    {
        var values = await _context.UserMessages.Where(x => x.ReceiverId == receiverId).ToListAsync();
        var mappedValues = _mapper.Map<List<ResultMessageDto>>(values);
        return mappedValues;
    }

    public async Task<ResultMessageDto> GetMessageById(int id)
    {
        var value = await _context.UserMessages.FindAsync(id);
        return _mapper.Map<ResultMessageDto>(value);
    }

    public async Task<List<ResultMessageDto>> GetSendBox(string senderId)
    {
        var values = await _context.UserMessages.Where(x => x.SenderId == senderId).ToListAsync();
        return _mapper.Map<List<ResultMessageDto>>(values);
    }

    public async Task UpdateMessage(ResultMessageDto dto)
    {
        dto.Status = "Görüldü";
        dto.SentDate = DateTime.UtcNow;
        var value = _mapper.Map<UserMessage>(dto);
        _context.Update(value);
        await _context.SaveChangesAsync();
    }
}
