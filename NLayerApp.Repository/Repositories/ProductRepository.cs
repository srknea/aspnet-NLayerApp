using Microsoft.EntityFrameworkCore;
using NLayerApp.Core.Model;
using NLayerApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductWithCategory()
        {
            // Eager Loading
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
