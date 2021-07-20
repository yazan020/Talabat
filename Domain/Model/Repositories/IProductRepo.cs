using System.Collections.Generic;
using System.Threading.Tasks;

namespace TalabatApi.Domain.Model.Repositories
{
    public interface IProductRepo
    {
        Task<Product> ProductExist(int id);
        Task<IEnumerable<Product>> GetProducts();
        Task<IEnumerable<Product>> SaveProduct(Product product);
        void UpdateProduct (Product product);
        void DeleteProduct(Product product);
    }
}