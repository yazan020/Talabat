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
            CreateMap<ProductDto, Product>(); 

            CreateMap<SaveRestDto, Restuarant>();
            CreateMap<UpdateRestDto, Restuarant>();

            CreateMap<SaveUserData, UserData>();

            CreateMap<OrderDto, Order>();
        }
        
    }
}