using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Persistence.Context;

namespace TalabatApi.Persistence.Repositories
{
    public class ProductRepo : BaseRepository, IProductRepo
    {
        public ProductRepo(DataContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> SaveProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            return await GetProducts();
        }
        public Task<Product> UpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
        public Task<IEnumerable<Product>> DeleteProduct(int productId)
        {
            throw new System.NotImplementedException();
        }



    }
}