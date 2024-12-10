using MediatR;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Commands.AddressCommands;
public class RemoveAddressCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}
