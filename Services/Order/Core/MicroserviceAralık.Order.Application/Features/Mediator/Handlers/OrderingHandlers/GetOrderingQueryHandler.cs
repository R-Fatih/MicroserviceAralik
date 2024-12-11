using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.OrderingResults;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
public class GetOrderingQueryHandler(IReadRepository<Ordering> _readRepository, IMapper _mapper) : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {

        var values = await _readRepository.GetAllAsync();
        return _mapper.Map<List<GetOrderingQueryResult>>(values);
    }
}
