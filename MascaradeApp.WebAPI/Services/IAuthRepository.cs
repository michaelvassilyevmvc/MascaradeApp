using MascaradeApp.WebAPI.DTO;

namespace MascaradeApp.WebAPI.Services;

public interface IAuthRepository
{
    bool IsUniqueUser(string userName);
    Task<LoginResponseDTO> Login(LoginRequestDTO loginRequest);
    Task<UserDTO> Register(RegistrationRequestDTO requestDto);
}