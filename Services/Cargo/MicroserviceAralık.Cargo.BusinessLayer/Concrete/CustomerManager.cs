using MicroserviceAralık.Cargo.BusinessLayer.Abstract;
using MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralık.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralık.Cargo.BusinessLayer.Concrete;
public class CustomerManager : GenericManager<Customer>, ICustomerService
{
    public CustomerManager(IGenericDal<Customer> genericDal) : base(genericDal)
    {
    }
}
