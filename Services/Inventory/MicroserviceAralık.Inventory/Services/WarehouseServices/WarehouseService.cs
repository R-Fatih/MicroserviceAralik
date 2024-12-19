using MicroserviceAralık.Inventory.Context;
using MicroserviceAralık.Inventory.Dtos.WarehouseDtos;
using MicroserviceAralık.Inventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Inventory.Services.WarehouseServices;

public class WarehouseService(AppDbContext _context) : IWarehouseService
{
    public async Task CreateWarehouse(CreateWarehouseDto dto)
    {
        var warehouse = new Warehouse
        {
            Location = dto.Location,
            Name = dto.Name
        };
        await _context.Warehouses.AddAsync(warehouse);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ResultWarehouseDto>> GetAllWarehouses()
    {
        return await _context.Warehouses.Select(x => new ResultWarehouseDto
        {
            Id = x.Id,
            Location = x.Location,
            Name = x.Name
        }).ToListAsync();
    }
}
