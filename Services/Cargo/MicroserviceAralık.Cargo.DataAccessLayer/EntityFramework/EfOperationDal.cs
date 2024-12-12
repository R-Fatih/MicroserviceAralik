using MicroserviceAralık.Cargo.DataAccessLayer.Abstract;
using MicroserviceAralık.Cargo.DataAccessLayer.Concrete;
using MicroserviceAralık.Cargo.DataAccessLayer.Repositories;
using MicroserviceAralık.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.Cargo.DataAccessLayer.EntityFramework;
public class EfOperationDal : GenericRepository<Operation>, IOperationDal
{
    public EfOperationDal(AppDbContext _context) : base(_context)
    {
    }

    public async Task<List<Operation>> GetOperationsByBarcodeNumber(string barcode)
    {
        return await _context.Operations.Where(x => x.Barcode == barcode).ToListAsync();

    }
}
