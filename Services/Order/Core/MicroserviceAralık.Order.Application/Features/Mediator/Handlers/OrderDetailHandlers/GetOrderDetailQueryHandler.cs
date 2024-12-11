using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.OrderDetailResults;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers;
public class GetOrderDetailQueryHandler(IReadRepository<OrderDetail> _readRepository, IMapper _mapper) : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
{
    public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
    {
        var values = await _readRepository.GetAllAsync();
        return _mapper.Map<List<GetOrderDetailQueryResult>>(values);
    }
}
