using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.AddressResults;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Queries.AddressQueries;
public class GetAddressQuery : IRequest<List<GetAddressQueryResult>>
{
}
