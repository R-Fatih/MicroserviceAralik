using Azure;

namespace MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
public interface IOperationDal : IGenericDal<Operation>
{
    Task<List<Operation>> GetOperationsByBarcodeNumber(string barcode);
}
