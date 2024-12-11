using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers;
public class RemoveOrderDetailCommandHandler(IWriteRepository<OrderDetail> _writeRepository) : IRequestHandler<RemoveOrderDetailCommand>
{
    public async Task Handle(RemoveOrderDetailCommand request, CancellationToken cancellationToken)
    {
        await _writeRepository.DeleteAsync(request.Id);
    }
}
