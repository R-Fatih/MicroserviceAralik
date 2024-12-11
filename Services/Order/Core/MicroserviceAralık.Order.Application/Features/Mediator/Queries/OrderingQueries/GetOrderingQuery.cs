using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.OrderingResults;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Queries.OrderingQueries;
public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
{
}
