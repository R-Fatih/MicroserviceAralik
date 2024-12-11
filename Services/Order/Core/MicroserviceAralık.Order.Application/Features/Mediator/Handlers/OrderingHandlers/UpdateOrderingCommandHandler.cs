using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
public class UpdateOrderingCommandHandler(IReadRepository<Ordering> _readRepository, IWriteRepository<Ordering> _writeRepository, IMapper _mapper) : IRequestHandler<UpdateOrderingCommand>
{
    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var value = await _readRepository.GetByIdAsync(request.Id);
        var updatedValue = _mapper.Map(request, value);
        await _writeRepository.UpdateAsync(updatedValue);
    }
}
