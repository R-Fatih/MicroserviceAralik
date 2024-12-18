using AutoMapper;
using MicroserviceAralık.Message.Dal.Entities;
using MicroserviceAralık.Message.Dtos;

namespace MicroserviceAralık.Message.Mapping;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<UserMessage, CreateMessageDto>().ReverseMap();
        CreateMap<UserMessage, ResultMessageDto>().ReverseMap();
    }
}
