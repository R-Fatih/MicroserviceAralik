using MediatR;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
public class CreateOrderDetailArrayCommand : IRequest
{
    public CreateOrderDetailArrayCommand(List<CreateOrderDetailCommand> list)
    {
        List = list;
    }

    public List<CreateOrderDetailCommand> List { get; set; }
}
