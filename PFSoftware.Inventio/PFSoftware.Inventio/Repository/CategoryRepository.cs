using PFSoftware.Inventio.Data;
using PFSoftware.Inventio.GenericRepository;
using PFSoftware.Inventio.Models;

namespace PFSoftware.Inventio.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
