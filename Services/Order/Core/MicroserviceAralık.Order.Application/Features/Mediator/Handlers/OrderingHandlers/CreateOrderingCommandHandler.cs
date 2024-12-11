using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
public class CreateOrderingCommandHandler(IWriteRepository<Ordering> _writeRepository, IMapper _mapper) : IRequestHandler<CreateOrderingCommand>
{
    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        var value = _mapper.Map<Ordering>(request);
        await _writeRepository.CreateAsync(value);
    }
}
