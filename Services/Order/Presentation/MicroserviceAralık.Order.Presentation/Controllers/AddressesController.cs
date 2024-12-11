using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.AddressCommands;
using MicroserviceAralık.Order.Application.Features.Mediator.Queries.AddressQueries;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Order.Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AddressesController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAddresses()
    {
        var result = await _mediator.Send(new GetAddressQuery());
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        var result = await _mediator.Send(new GetAddressByIdQuery(id));
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
    {
        await _mediator.Send(command);
        return Ok("Address created successfully!");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
    {
        await _mediator.Send(command);
        return Ok("Address updated successfully!");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        await _mediator.Send(new RemoveAddressCommand(id));
        return Ok("Address deleted successfully!");
    }
}
