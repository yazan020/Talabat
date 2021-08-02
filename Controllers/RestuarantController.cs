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
    public class RestuarantController : ControllerBase
    {
        private readonly IRestaurantService _service;
        private readonly IMapper _mapper;

        public RestuarantController(IRestaurantService service, IMapper mapper)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetRests()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var response = await _service.GetRests();

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveRest(SaveRestDto restuarantDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var rest = _mapper.Map<SaveRestDto, Restuarant>(restuarantDto);
            var response = await _service.SaveRest(rest);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRest(int Id, UpdateRestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var restUpdate = _mapper.Map<UpdateRestDto, Restuarant>(updateDto);

            var response = await _service.UpdateRest(Id, restUpdate);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRest(int Id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState.GetErrorMessage());

            var response = await _service.DeleteRest(Id);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}