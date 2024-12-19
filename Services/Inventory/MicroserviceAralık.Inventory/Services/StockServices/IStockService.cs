using MicroserviceAralık.Inventory.Dtos.StockDtos;

namespace MicroserviceAralık.Inventory.Services.StockServices;

public interface IStockService
{
    Task CreateStock(CreateStockDto dto);
    Task<List<ResultStockDto>> GetAllStocks();
    Task<bool> ReserveInventory(string productId, int quantity);
    Task<bool> RollbackInventory(string productId, int quantity);
}
