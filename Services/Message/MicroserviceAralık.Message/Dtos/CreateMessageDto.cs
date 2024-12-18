namespace MicroserviceAralık.Message.Dtos;

public class CreateMessageDto
{
    public int Id { get; set; }
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }

}
