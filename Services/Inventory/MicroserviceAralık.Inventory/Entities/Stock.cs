namespace MicroserviceAralık.Inventory.Entities;

public class Stock
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public int WarehouseId { get; set; }
    public DateTime LastUpdate { get; set; }
    public Warehouse Warehouse { get; set; }
}
