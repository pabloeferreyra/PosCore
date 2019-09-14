using PFSoftware.Inventio.Data;
using PFSoftware.Inventio.GenericRepository;
using PFSoftware.Inventio.Models;

namespace PFSoftware.Inventio.Repository
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
