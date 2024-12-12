
using MicroserviceAralık.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
public interface IOperationDal : IGenericDal<Operation>
{
    Task<List<Operation>> GetOperationsByBarcodeNumber(string barcode);
}
