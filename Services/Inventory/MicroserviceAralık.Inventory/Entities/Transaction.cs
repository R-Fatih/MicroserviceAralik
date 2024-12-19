namespace MicroserviceAralık.Inventory.Entities;

public class Transaction
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public string Type { get; set; } //in ya da out
    public DateTime EventTime { get; set; }
    public string Description { get; set; }
}
