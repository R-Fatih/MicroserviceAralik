using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.OrderDetailResults;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers;
public class GetOrderDetailByIdQueryHandler(IReadRepository<OrderDetail> _readRepository, IMapper _mapper) : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
{
    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _readRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetOrderDetailByIdQueryResult>(value);
    }
}
