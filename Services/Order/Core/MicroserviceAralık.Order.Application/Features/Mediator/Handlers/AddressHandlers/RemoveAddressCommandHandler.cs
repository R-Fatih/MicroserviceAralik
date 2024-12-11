using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.AddressCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.AddressHandlers;
public class RemoveAddressCommandHandler(IWriteRepository<Address> _writeRepository) : IRequestHandler<RemoveAddressCommand>
{
    public async Task Handle(RemoveAddressCommand request, CancellationToken cancellationToken)
    {

        await _writeRepository.DeleteAsync(request.Id);
    }
}
