using System.Collections.Generic;
using System.Threading.Tasks;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Repositories;
using TalabatApi.Domain.Model.Services;
using TalabatApi.Domain.Model.Services.Communication;

namespace TalabatApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repository;
        private readonly IUnitOfWork _workUnit;

        public ProductService(IProductRepo repository, IUnitOfWork workUnit)
        {
            this._workUnit = workUnit;
            this._repository = repository;

        }

        public async Task<Response<IEnumerable<Product>>> GetProducts()
        {
            var product = await _repository.GetProducts();
            if (product == null)
            {
                return new Response<IEnumerable<Product>>("there is no Products available");
            }

            var productResponse = new Response<IEnumerable<Product>>(product, "product listed successfully");
            return productResponse;
        }

        public async Task<Response<IEnumerable<Product>>> SaveProduct(Product product)
        {
            if (product == null)
            {
                return new Response<IEnumerable<Product>>("Please enter a valid data");
            }

            var Savedproduct = await _repository.SaveProduct(product);

            await _workUnit.SaveAsync();

            return new Response<IEnumerable<Product>>(Savedproduct, "Product Saved successfully");
        }

        public Task<Response<Product>> UpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response<IEnumerable<Product>>> DeleteProduct(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}