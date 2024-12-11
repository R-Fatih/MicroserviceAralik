using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers;
public class UpdateOrderDetailCommandHandler(IReadRepository<OrderDetail> _readRepository, IWriteRepository<OrderDetail> _writeRepository, IMapper _mapper) : IRequestHandler<UpdateOrderDetailCommand>
{
    public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var values = await _readRepository.GetByIdAsync(request.Id);
        var mapped = _mapper.Map(request, values);
        await _writeRepository.UpdateAsync(mapped);
    }
}
