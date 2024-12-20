using MicroserviceAralık.RabbitMQ.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.Payment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PaymentsController : ControllerBase
{
    private readonly IRabbitMQPublisher _rabbitMQPublisher;

    public PaymentsController(IRabbitMQPublisher rabbitMQPublisher)
    {
        _rabbitMQPublisher = rabbitMQPublisher;
    }

    [HttpGet]
    public async Task<IActionResult> MakePayment(bool paymentStatus)
    {
        _rabbitMQPublisher.Publish<bool>("PaymentStatusQueue", paymentStatus);
        return Ok(paymentStatus);
    }
}
