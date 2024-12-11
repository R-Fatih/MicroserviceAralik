using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers;
public class CreateOrderDetailCommandHandler(IWriteRepository<OrderDetail> _writeRepository, IMapper _mapper) : IRequestHandler<CreateOrderDetailCommand>
{
    public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {

        var value = _mapper.Map<OrderDetail>(request);
        await _writeRepository.CreateAsync(value);
    }
}
