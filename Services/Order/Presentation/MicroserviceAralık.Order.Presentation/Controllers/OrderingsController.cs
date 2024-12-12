using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MicroserviceAralık.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Order.Presentation.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrderingsController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOrderinges()
    {
        var result = await _mediator.Send(new GetOrderingQuery());
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderingById(int id)
    {
        var result = await _mediator.Send(new GetOrderingByIdQuery(id));
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
    {
        await _mediator.Send(command);
        return Ok("Ordering created successfully!");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
    {
        await _mediator.Send(command);
        return Ok("Ordering updated successfully!");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteOrdering(int id)
    {
        await _mediator.Send(new RemoveOrderingCommand(id));
        return Ok("Ordering deleted successfully!");
    }
}
