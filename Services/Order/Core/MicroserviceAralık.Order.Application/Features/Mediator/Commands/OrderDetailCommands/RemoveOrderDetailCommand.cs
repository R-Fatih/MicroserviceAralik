using MediatR;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
public class RemoveOrderDetailCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}
