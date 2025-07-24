using AutoMapper;
using MascaradeApp.WebAPI.DTO;
using MascaradeApp.WebAPI.Entities;

namespace MascaradeApp.WebAPI.Profiles;

public class CustomerProfile: Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerDto, Customer>().ReverseMap();
        CreateMap<CustomerUpdateDto, Customer>().ReverseMap();
        CreateMap<CustomerUpdateDto, CustomerDto>().ReverseMap();
        CreateMap<CustomerCreateDto, Customer>().ReverseMap();
        CreateMap<CustomerCreateDto, CustomerDto>().ReverseMap();
    }
}