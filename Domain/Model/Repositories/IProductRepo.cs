using System.Collections.Generic;
using System.Threading.Tasks;

namespace TalabatApi.Domain.Model.Repositories
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> SaveProduct(Product product);
        Task<Product> UpdateProduct (Product product);
        Task<IEnumerable<Product>> DeleteProduct(int productId);
    }
}