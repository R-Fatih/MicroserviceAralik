using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
public class RemoveOrderingCommandHandler(IWriteRepository<Ordering> _writeRepository) : IRequestHandler<RemoveOrderingCommand>
{
    public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
    {
        await _writeRepository.DeleteAsync(request.Id);

    }
}
