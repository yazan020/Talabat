using AutoMapper;
using TalabatApi.Domain.Model;
using TalabatApi.Domain.Model.Dtos;

namespace TalabatApi.Mapper
{
    public class AutoMapper : Profile
    {

        public AutoMapper()
        {
            CreateMap<AuthenticateUserDto, User>();
        }
        
    }
}