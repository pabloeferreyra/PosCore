using PFSoftware.Inventio.Data;
using PFSoftware.Inventio.GenericRepository;
using PFSoftware.Inventio.Models;

namespace PFSoftware.Inventio.Repository
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
