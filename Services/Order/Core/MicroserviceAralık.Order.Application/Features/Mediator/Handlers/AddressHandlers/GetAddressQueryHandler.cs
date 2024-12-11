using AutoMapper;
using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Queries.AddressQueries;
using MicroserviceAralık.Order.Application.Features.Mediator.Results.AddressResults;
using MicroserviceAralık.Order.Application.Interfaces;
using MicroserviceAralık.Order.Domain.Entities;

namespace MicroserviceAralık.Order.Application.Features.Mediator.Handlers.AddressHandlers;
public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, List<GetAddressQueryResult>>
{
    private readonly IReadRepository<Address> _readRepository;
    private readonly IMapper _mapper;

    public GetAddressQueryHandler(IReadRepository<Address> readRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAddressQueryResult>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
    {

        var values = await _readRepository.GetAllAsync();
        return _mapper.Map<List<GetAddressQueryResult>>(values);
    }
}
