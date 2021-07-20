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

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task<Product> ProductExist(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}