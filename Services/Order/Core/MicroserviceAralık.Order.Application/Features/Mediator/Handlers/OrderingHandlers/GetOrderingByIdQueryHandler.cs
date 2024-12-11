using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.OrderingResults;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
public class GetOrderingByIdQueryHandler(IReadRepository<Ordering> _readRepository, IMapper _mapper) : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _readRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetOrderingByIdQueryResult>(value);
    }
}
