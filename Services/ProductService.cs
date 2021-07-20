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

        public async Task<Response<Product>> UpdateProduct(int id, Product product)
        {
            var existingProduct = await _repository.ProductExist(id);

            if (existingProduct == null)
            {
                return new Response<Product>("Please provide the product info");
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;


            try
            {
                _repository.UpdateProduct(existingProduct);
                await _workUnit.SaveAsync();

                return new Response<Product>(existingProduct, "product updated successfully");
            }
            catch (System.Exception ex)
            {
                return new Response<Product>($"An error occurred when updating the product ${ex.Message}");
            }

        }

        public async Task<Response<IEnumerable<Product>>> DeleteProduct(int productId)
        {
            var deletedProduct = await _repository.ProductExist(productId);

            if (deletedProduct is null)
            {
                return new Response<IEnumerable<Product>>("Product was not found");
            }

            try
            {
                _repository.DeleteProduct(deletedProduct);

                await _workUnit.SaveAsync();

                return new Response<IEnumerable<Product>>(await _repository.GetProducts(), "product deleted successfully");

            }
            catch (System.Exception ex)
            {
                return new Response<IEnumerable<Product>>($"An error occurred when deleting the product ${ex.Message}");
            }

        }
    }
}