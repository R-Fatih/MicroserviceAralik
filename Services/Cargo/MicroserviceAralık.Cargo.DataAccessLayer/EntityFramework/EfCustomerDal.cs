using MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralık.Cargo.DataAccessLayer.Concrete;
using MicroserviceAralık.Cargo.DataAccessLayer.Repositories;
using MicroserviceAralık.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralık.Cargo.DataAccessLayer.EntityFramework;
public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
{
    public EfCustomerDal(AppDbContext _context) : base(_context)
    {
    }
}
