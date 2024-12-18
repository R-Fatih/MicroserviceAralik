using MicroserviceAralık.Message.Dtos;
using MicroserviceAralık.Message.Services.RabbitMqServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Message.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MessagesController(RabbitMQPublisher _rabbitMQPublisher) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SendMessage(CreateMessageDto dto)
    {
        _rabbitMQPublisher.Publish(dto);
        return Ok("Mesaj başarıyla kuyruğa eklendi");
    }
}
