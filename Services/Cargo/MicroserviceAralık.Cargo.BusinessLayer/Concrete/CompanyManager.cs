using MicroserviceAralık.Cargo.BusinessLayer.Abstract;
using MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralık.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralık.Cargo.BusinessLayer.Concrete;
public class CompanyManager : GenericManager<Company>, ICompanyService
{
    public CompanyManager(IGenericDal<Company> genericDal) : base(genericDal)
    {
    }
}
