using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.WebAPI.Data;

namespace Udemy.WebAPI.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsyncApi();
        public Task<Product> GetByIdAsyncApi(int id);
        public Task<Product> CreateAsyncApi(Product product);
        public Task UpdateAsyncApi(Product product);
        public Task RemoveAsyncApi(int id);
        
    }
}
