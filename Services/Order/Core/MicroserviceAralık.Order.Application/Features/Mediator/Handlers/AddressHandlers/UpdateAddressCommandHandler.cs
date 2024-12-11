using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.AddressCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.AddressHandlers;
public class UpdateAddressCommandHandler(IReadRepository<Address> _readRepository, IWriteRepository<Address> _writeRepository, IMapper _mapper) : IRequestHandler<UpdateAddressCommand>
{
    public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
    {
        var value = await _readRepository.GetByIdAsync(request.Id);
        var mappedValue = _mapper.Map(request, value);
        await _writeRepository.UpdateAsync(mappedValue);

    }
}
