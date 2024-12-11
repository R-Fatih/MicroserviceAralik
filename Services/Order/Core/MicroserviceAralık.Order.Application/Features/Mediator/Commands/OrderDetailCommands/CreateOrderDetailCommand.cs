using MediatR;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
public class CreateOrderDetailCommand : IRequest
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public decimal TotalPrice { get; set; }
    public int OrderingId { get; set; }
}
