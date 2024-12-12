using MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralık.Cargo.DataAccessLayer.Concrete;
using MicroserviceAralık.Cargo.DataAccessLayer.Repositories;
using MicroserviceAralık.Cargo.EntityLayer.Concrete;

namespace MicroserviceAralık.Cargo.DataAccessLayer.EntityFramework;
public class EfCompanyDal : GenericRepository<Company>, ICompanyDal
{
    public EfCompanyDal(AppDbContext _context) : base(_context)
    {
    }
}
