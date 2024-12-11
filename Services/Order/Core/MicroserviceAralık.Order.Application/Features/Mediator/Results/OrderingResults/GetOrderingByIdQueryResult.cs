namespace MicroserviceAralık.Order.Application.Features.Mediator.Results.OrderingResults;
public class GetOrderingByIdQueryResult
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
