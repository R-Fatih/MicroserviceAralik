using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.AddressResults;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Queries.AddressQueries;
public class GetAddressByIdQuery(int id) : IRequest<GetAddressByIdQueryResult>
{
    public int Id { get; set; } = id;
}
