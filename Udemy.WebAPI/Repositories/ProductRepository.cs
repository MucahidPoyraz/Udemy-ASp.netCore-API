using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.WebAPI.Data;
using Udemy.WebAPI.Interfaces;

namespace Udemy.WebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsyncApi(Product product)
        {
           await _context.Products.AddAsync(product);
           await _context.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllAsyncApi()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsyncApi(int id)
        {
           return await _context.Products.FindAsync(id);
        }

        public async Task RemoveAsyncApi(int id)
        {
            var removedEntity = await _context.Products.FindAsync(id);
            _context.Products.Remove(removedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsyncApi(Product product)
        {
            var unchangedEntity = await _context.Products.FindAsync(product.Id);
            _context.Entry(unchangedEntity).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
        }
    }
}
