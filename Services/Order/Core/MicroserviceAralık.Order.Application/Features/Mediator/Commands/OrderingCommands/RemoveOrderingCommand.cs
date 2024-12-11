using MediatR;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderingCommands;
public class RemoveOrderingCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}
