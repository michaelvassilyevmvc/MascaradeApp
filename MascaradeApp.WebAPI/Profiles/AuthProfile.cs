using AutoMapper;
using MascaradeApp.WebAPI.DTO;
using MascaradeApp.WebAPI.Models;

namespace MascaradeApp.WebAPI.Profiles;

public class AuthProfile: Profile
{
    public AuthProfile()
    {
        CreateMap<ApplicationUser, UserDTO>()
            .ReverseMap();
    }
}