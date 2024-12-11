using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.OrderDetailResults;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
public class GetOrderDetailQuery : IRequest<List<GetOrderDetailQueryResult>>
{
}
