namespace MicroserviceAralık.Message.Dal.Entities;

public class UserMessage
{
    public int Id { get; set; }
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime SentDate { get; set; }
    public string Status { get; set; }
}
