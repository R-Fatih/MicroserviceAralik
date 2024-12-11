using MediatR;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderingCommands;
public class UpdateOrderingCommand : IRequest
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
