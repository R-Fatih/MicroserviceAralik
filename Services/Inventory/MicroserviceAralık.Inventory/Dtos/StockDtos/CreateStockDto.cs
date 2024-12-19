namespace MicroserviceAralık.Inventory.Dtos.StockDtos;

public class CreateStockDto
{
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public int WarehouseId { get; set; }

}
