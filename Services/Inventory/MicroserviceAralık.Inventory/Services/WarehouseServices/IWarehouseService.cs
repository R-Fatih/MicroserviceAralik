using MicroserviceAralık.Inventory.Dtos.WarehouseDtos;

namespace MicroserviceAralık.Inventory.Services.WarehouseServices;

public interface IWarehouseService
{
    Task<List<ResultWarehouseDto>> GetAllWarehouses();
    Task CreateWarehouse(CreateWarehouseDto dto);
}
