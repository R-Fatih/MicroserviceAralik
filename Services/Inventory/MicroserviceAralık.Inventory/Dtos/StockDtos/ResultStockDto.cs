namespace MicroserviceAralık.Inventory.Dtos.StockDtos;

public class ResultStockDto
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public int WarehouseId { get; set; }
    public DateTime LastUpdate { get; set; }
}
