using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Dtos;
using TalabatApi.Domain.Model.Services;
using TalabatApi.Domain.Model.Services.Communication;
using TalabatApi.Extensions;
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

        [HttpGet]
        public async Task<IActionResult> Register(int UserId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var result = await _service
                    .SeeUserData(UserId);
                    
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(AuthenticateUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var result = await _service
                    .RegisterUser(new User { Name = userDto.Name }, userDto.password);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthenticateUserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var result = await _service.LoginUser(new User { Name = userDto.Name }, userDto.password);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("userInfo")]
        public async Task<IActionResult> UpdateUserInfo(SaveUserData userDataDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var userData = _mapper.Map<SaveUserData, UserData>(userDataDto);

            var result = await _service.AddUserDataInfo(userData);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}