using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Dtos;
using TalabatApi.Domain.Model.Services;
using TalabatApi.Extensions;
using TalabatApi.Services;

namespace TalabatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IRestaurantService _restService;
        private readonly IMapper _mapper;

        public OrderController(IRestaurantService restService, IOrderService orderService, IMapper mapper)
        {
            this._mapper = mapper;
            this._restService = restService;
            this._orderService = orderService;

        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());


            var response = await _orderService.GetOrderById(id);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("UserId")]
        public async Task<IActionResult> GetOrderByUserId(int UserId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());


            var response = await _orderService.GetOrdersByUser(UserId);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet()]
        public async Task<IActionResult> GetOrders()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());


            var response = await _orderService.GetOrders();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(OrderDto order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var ordered = _mapper.Map<OrderDto, Order>(order);

            var response = await _orderService.AddOrder(ordered);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}