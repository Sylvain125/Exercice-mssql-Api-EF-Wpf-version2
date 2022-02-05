using AutoMapper;
using Exercice.Dto;
using Exercice.Entity;

internal class ProfileApi : Profile
{
    // Le profile pour automapper cote api
    public ProfileApi()
    {
        CreateMap<UserEntity, UserDto>().ReverseMap();
        CreateMap<OrderEntity, OrderDto>().ReverseMap();
        CreateMap<ProductEntity, ProductDto>().ReverseMap();
    }
}