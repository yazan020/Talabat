using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Dtos;
using TalabatApi.Domain.Model.Services;
using TalabatApi.Domain.Model.Services.Communication;
using TalabatApi.Services;

namespace TalabatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IMapper _mapper;
        public AuthenticationController(IAuthService service, IMapper mapper)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Register(AuthenticateUserDto userDto)
        {
            var result = await _service
                    .RegisterUser(new User{Name = userDto.Name}, userDto.password);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            
            return Ok(result);
        }
    }
}