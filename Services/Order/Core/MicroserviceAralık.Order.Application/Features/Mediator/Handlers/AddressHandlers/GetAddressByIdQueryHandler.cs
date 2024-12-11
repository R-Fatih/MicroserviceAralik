using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Queries.AddressQueries;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.AddressResults;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.AddressHandlers;
public class GetAddressByIdQueryHandler(IReadRepository<Address> _readRepository, IMapper _mapper) : IRequestHandler<GetAddressByIdQuery, GetAddressByIdQueryResult>
{
    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {

        var value = await _readRepository.GetByIdAsync(request.Id);
        return _mapper.Map<GetAddressByIdQueryResult>(value);
    }
}
