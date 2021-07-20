using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Dtos;
using TalabatApi.Domain.Model.Services;
using TalabatApi.Domain.Model.Services.Communication;
using TalabatApi.Extensions;

namespace TalabatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductController(IProductService service, IMapper mapper)
        {
            this._mapper = mapper;
            this._service = service;

        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var response = await _service.GetProducts();
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            // var dataResponse =  _mapper.Map<IEnumerable<ProductDto>>(response);

            // response.Data = dataResponse;

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var product = _mapper.Map<ProductDto, Product>(productDto);

            var response = await _service.SaveProduct(product);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
        //     Server=192.168.8.16,3306; Database=Talabat; User Id=test; Password=DataTest
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var product = _mapper.Map<ProductDto, Product>(productDto);

            var response = await _service.UpdateProduct(id, product);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var response = await _service.DeleteProduct(id);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
    }
}