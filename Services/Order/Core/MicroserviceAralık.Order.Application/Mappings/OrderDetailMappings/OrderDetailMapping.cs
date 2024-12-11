using AutoMapper;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.OrderDetailResults;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Mappings.OrderDetailMappings;
public class OrderDetailMapping : Profile
{
    public OrderDetailMapping()
    {
        CreateMap<OrderDetail, CreateOrderDetailCommand>().ReverseMap();
        CreateMap<OrderDetail, UpdateOrderDetailCommand>().ReverseMap();
        CreateMap<OrderDetail, GetOrderDetailByIdQueryResult>().ReverseMap();
        CreateMap<OrderDetail, GetOrderDetailQueryResult>().ReverseMap();
    }
}
