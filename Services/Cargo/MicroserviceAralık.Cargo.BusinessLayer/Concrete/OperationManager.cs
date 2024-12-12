using MicroserviceAralık.Cargo.BusinessLayer.Abstract;
using MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralık.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralık.Cargo.BusinessLayer.Concrete;
public class OperationManager : GenericManager<Operation>, IOperationService
{
    private readonly IOperationDal _operationDal;

    public OperationManager(IGenericDal<Operation> genericDal, IOperationDal operationDal) : base(genericDal)
    {
        _operationDal = operationDal;
    }

    public async Task<List<Operation>> GetOperationsByBarcodeNumber(string barcode)
    {
        return await _operationDal.GetOperationsByBarcodeNumber(barcode);
    }
}
