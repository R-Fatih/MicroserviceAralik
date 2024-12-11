using AutoMapper;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.OrderingResults;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Mappings.OrderingMappings;
public class OrderingMapping : Profile
{
    public OrderingMapping()
    {
        CreateMap<Ordering, GetOrderingQueryResult>().ReverseMap();
        CreateMap<Ordering, GetOrderingByIdQueryResult>().ReverseMap();
        CreateMap<Ordering, CreateOrderingCommand>().ReverseMap();
        CreateMap<Ordering, UpdateOrderingCommand>().ReverseMap();
    }
}
