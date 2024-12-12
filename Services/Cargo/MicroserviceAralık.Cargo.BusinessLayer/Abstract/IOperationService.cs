using MicroserviceAralık.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralık.Cargo.BusinessLayer.Abstract;
public interface IOperationService : IGenericService<Operation>
{
    Task<List<Operation>> GetOperationsByBarcodeNumber(string barcode);
}
