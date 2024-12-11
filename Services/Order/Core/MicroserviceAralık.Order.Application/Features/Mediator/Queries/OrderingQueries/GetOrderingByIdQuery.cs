using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Queries.OrderingQueries;
public class GetOrderingByIdQuery(int id) : IRequest<GetOrderingByIdQueryResult>
{
    public int Id { get; set; } = id;
}
