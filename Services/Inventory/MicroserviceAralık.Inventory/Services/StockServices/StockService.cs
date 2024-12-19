using MicroserviceAralık.Inventory.Context;
using MicroserviceAralık.Inventory.Dtos.StockDtos;
using MicroserviceAralık.Inventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Inventory.Services.StockServices;

public class StockService(AppDbContext _context) : IStockService
{
    public async Task CreateStock(CreateStockDto dto)
    {
        var stock = new Stock
        {
            LastUpdate = DateTime.UtcNow,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            WarehouseId = dto.WarehouseId
        };
        await _context.Stocks.AddAsync(stock);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ResultStockDto>> GetAllStocks()
    {
        return await _context.Stocks.Select(x => new ResultStockDto
        {
            Id = x.Id,
            LastUpdate = x.LastUpdate,
            ProductId = x.ProductId,
            Quantity = x.Quantity,
            WarehouseId = x.WarehouseId
        }).ToListAsync();
    }

    public Task<bool> ReserveInventory(string productId, int quantity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RollbackInventory(string productId, int quantity)
    {
        throw new NotImplementedException();
    }
}
