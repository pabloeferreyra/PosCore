using PFSoftware.Inventio.Data;
using PFSoftware.Inventio.GenericRepository;
using PFSoftware.Inventio.Models;

namespace PFSoftware.Inventio.Repository
{
    public class SaleProductRepository : GenericRepository<SaleProduct>, ISaleProductRepository
    {
        public SaleProductRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
