using MicroserviceAralık.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
public interface ICargoDetailDal : IGenericDal<CargoDetail>
{
    Task<List<CargoDetail>> GetSentCargoDetailByCustomerId(int customerId);
    Task<List<CargoDetail>> GetReceivedCargoDetailByCustomerId(int customerId);
}
