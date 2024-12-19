using MediatR;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderingCommands;
public class CreateOrderingCommand : IRequest<int>
{
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
