using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.AddressCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.AddressHandlers;
public class CreateAddressCommandHandler(IWriteRepository<Address> _writeRepository, IMapper _mapper) : IRequestHandler<CreateAddressCommand>
{
    public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {

        var value = _mapper.Map<Address>(request);
        await _writeRepository.CreateAsync(value);
    }
}
