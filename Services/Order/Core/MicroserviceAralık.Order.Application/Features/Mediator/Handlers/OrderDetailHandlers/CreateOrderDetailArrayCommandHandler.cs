using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers;
public class CreateOrderDetailArrayCommandHandler(IWriteRepository<OrderDetail> _writeRepository, IMapper _mapper) : IRequestHandler<CreateOrderDetailArrayCommand>
{
    public async Task Handle(CreateOrderDetailArrayCommand request, CancellationToken cancellationToken)
    {

        var mapped = _mapper.Map<List<OrderDetail>>(request.List);
        await _writeRepository.CreateArrayAsync(mapped);
    }
}
