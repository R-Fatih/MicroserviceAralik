using MediatR;
using MicroserviceAralık.Order.Application.Features.Mediator.Commands.OrderDetailCommands;
using MicroserviceAralık.Order.Application.Features.Mediator.Queries.OrderDetailQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Order.Presentation.Controllers;
[Authorize]
[Route("api/[controller]")]
[ApiController]
public class OrderDetailController(IMediator _mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOrderDetailes()
    {
        var result = await _mediator.Send(new GetOrderDetailQuery());
        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailById(int id)
    {
        var result = await _mediator.Send(new GetOrderDetailByIdQuery(id));
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
    {
        await _mediator.Send(command);
        return Ok("OrderDetail created successfully!");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
    {
        await _mediator.Send(command);
        return Ok("OrderDetail updated successfully!");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        await _mediator.Send(new RemoveOrderDetailCommand(id));
        return Ok("OrderDetail deleted successfully!");
    }
}
