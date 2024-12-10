using AutoMapper;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.AddressCommands;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.AddressResults;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Mappings.AddressMappings;
public class AddressMapping : Profile
{
    public AddressMapping()
    {
        CreateMap<Address, CreateAddressCommand>().ReverseMap();
        CreateMap<Address, UpdateAddressCommand>().ReverseMap();
        CreateMap<Address, GetAddressQueryResult>().ReverseMap();
        CreateMap<Address, GetAddressByIdQueryResult>().ReverseMap();
    }
}
