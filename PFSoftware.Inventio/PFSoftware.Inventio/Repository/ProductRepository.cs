using PFSoftware.Inventio.Data;
using PFSoftware.Inventio.GenericRepository;
using PFSoftware.Inventio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFSoftware.Inventio.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
