using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralık.Order.Application.Interfaces;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.OrderDetailHandlers;
public class UpdateOrderDetailCommandHandler(IOrderDetailRepository _orderDetailRepository, IMapper _mapper) : IRequestHandler<UpdateOrderDetailCommand>
{
    public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        await _orderDetailRepository.UpdateOrderDetail(request);
    }
}
