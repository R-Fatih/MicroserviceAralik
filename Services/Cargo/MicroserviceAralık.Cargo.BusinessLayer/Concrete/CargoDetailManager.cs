using MicroserviceAralık.Cargo.BusinessLayer.Abstract;
using MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralık.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralık.Cargo.BusinessLayer.Concrete;
public class CargoDetailManager : GenericManager<CargoDetail>, ICargoDetailService
{

    private readonly ICargoDetailDal _cargoDetailDal;

    public CargoDetailManager(IGenericDal<CargoDetail> genericDal, ICargoDetailDal cargoDetailDal) : base(genericDal)
    {
        _cargoDetailDal = cargoDetailDal;
    }

    public async Task<List<CargoDetail>> GetReceivedCargoDetailByCustomerId(int customerId)
    {
        return await _cargoDetailDal.GetReceivedCargoDetailByCustomerId(customerId);
    }

    public async Task<List<CargoDetail>> GetSentCargoDetailByCustomerId(int customerId)
    {
        return await _cargoDetailDal.GetSentCargoDetailByCustomerId(customerId);
    }
}
