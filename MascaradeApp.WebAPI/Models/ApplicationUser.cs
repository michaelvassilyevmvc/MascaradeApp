using Microsoft.AspNetCore.Identity;

namespace MascaradeApp.WebAPI.Models;

public class ApplicationUser: IdentityUser
{
    public string Name { get; set; }
}