using MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralık.Cargo.DataAccessLayer.Concrete;
using MicroserviceAralık.Cargo.DataAccessLayer.Repositories;
using MicroserviceAralık.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Cargo.DataAccessLayer.EntityFramework;
public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
{
    public EfCargoDetailDal(AppDbContext _context) : base(_context)
    {
    }

    public async Task<List<CargoDetail>> GetReceivedCargoDetailByCustomerId(int customerId)
    {

        return await _context.CargoDetails.Where(x => x.ReceiverCustomerId == customerId).ToListAsync();
    }

    public async Task<List<CargoDetail>> GetSentCargoDetailByCustomerId(int customerId)
    {
        return await _context.CargoDetails.Where(x => x.SenderCustomerId == customerId).ToListAsync();
    }
}
