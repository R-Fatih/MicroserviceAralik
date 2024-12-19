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

    public async Task<bool> ReserveInventory(string productId, int quantity)
    {

        var product = await _context.Stocks.FirstOrDefaultAsync(x => x.ProductId == productId);
        if (product == null || product.Quantity < quantity)
            return false;
        product.Quantity -= quantity;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> RollbackInventory(string productId, int quantity)
    {

        var product = await _context.Stocks.FirstOrDefaultAsync(x => x.ProductId == productId);
        if (product == null)
            return false;
        product.Quantity += quantity;
        await _context.SaveChangesAsync();
        return true;
    }
}
