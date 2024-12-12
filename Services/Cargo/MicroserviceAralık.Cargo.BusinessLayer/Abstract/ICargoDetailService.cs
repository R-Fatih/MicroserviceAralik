using MicroserviceAralık.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralık.Cargo.BusinessLayer.Abstract;
public interface ICargoDetailService : IGenericService<CargoDetail>
{
    Task<List<CargoDetail>> GetSentCargoDetailByCustomerId(int customerId);
    Task<List<CargoDetail>> GetReceivedCargoDetailByCustomerId(int customerId);
}
