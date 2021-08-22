using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Services;
using TalabatApi.Extensions;
using Ubiety.Dns.Core;

namespace TalabatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _service;
        private readonly IMapper _mapper;

        public DriverController(IDriverService service, IMapper mapper)
        {
            this._mapper = mapper;
            this._service = service;
        }



        [HttpPost]
        public async Task<IActionResult> AssignDriver(Driver driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var result = await _service.AssignDriver(driver);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDriverLocation(Driver driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var result = await _service.UpdateDriverLocation(driver);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DissaproveDriver(Driver driver)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var result = await _service.DisapproveDriver(driver);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet]
        public string GetIp()
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;

            return remoteIpAddress.ToString();
        }

    }
}