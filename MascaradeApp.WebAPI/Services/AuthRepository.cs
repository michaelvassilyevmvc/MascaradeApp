using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using MascaradeApp.WebAPI.Data;
using MascaradeApp.WebAPI.DTO;
using MascaradeApp.WebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace MascaradeApp.WebAPI.Services;

public class AuthRepository : IAuthRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private string secretKey;

    public AuthRepository(ApplicationDbContext db, IConfiguration configuration, IMapper mapper,
        UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _db = db;
        _configuration = configuration;
        _mapper = mapper;
        _userManager = userManager;
        _roleManager = roleManager;
        secretKey = _configuration.GetValue<string>("ApiSettings:SecretKey");
    }

    public bool IsUniqueUser(string userName)
    {
        var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == userName);
        return user == null;
    }

    public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto)
    {
        var user = _db.ApplicationUsers.SingleOrDefault(x =>
            x.UserName == loginRequestDto.UserName);
        bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
        if (user == null || isValid == false)
        {
            return null;
        }

        var roles = await _userManager.GetRolesAsync(user);
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secretKey);
        var tokenDescription = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescription);
        LoginResponseDTO loginResponseDto = new()
        {
            User = _mapper.Map<UserDTO>(user),
            Token = new JwtSecurityTokenHandler().WriteToken(token),
        };
        return loginResponseDto;
    }

    public async Task<UserDTO> Register(RegistrationRequestDTO requestDto)
    {
        ApplicationUser userObj = new()
        {
            UserName = requestDto.UserName,
            Name = requestDto.Name,
            NormalizedUserName = requestDto.UserName.ToUpper(),
            Email = requestDto.UserName
        };
        try
        {
            var result = await _userManager.CreateAsync(userObj, requestDto.Password);
            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync("admin")
                        .GetAwaiter()
                        .GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                    await _roleManager.CreateAsync(new IdentityRole("customer"));
                }

                await _userManager.AddToRoleAsync(userObj, "admin");
                var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == userObj.UserName);
                return _mapper.Map<UserDTO>(user);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return null;
    }
}