using System.Collections.Generic;
using System.Threading.Tasks;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Domain.Model.Services
{
    public interface IProductService
    {
        Task<Response<IEnumerable<Product>>> GetProducts();
        Task<Response<IEnumerable<Product>>> SaveProduct(Product product);
        Task<Response<Product>> UpdateProduct(Product product);
        Task<Response<IEnumerable<Product>>> DeleteProduct(int productId);
    }
}