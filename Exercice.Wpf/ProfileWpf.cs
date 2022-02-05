using AutoMapper;
using Exercice.Dto;
using Exercice.Model;

namespace Exercice.Wpf
{
    public class ProfileWpf : Profile
    {
        public ProfileWpf()
        {
            CreateMap<UserDto, UserModel>().ReverseMap();
            CreateMap<OrderDto, OrderModel>().ReverseMap();
            CreateMap<ProductDto, ProductModel>().ReverseMap();
        }
    }
}
