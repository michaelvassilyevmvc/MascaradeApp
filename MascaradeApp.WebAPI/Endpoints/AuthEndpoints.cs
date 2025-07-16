using System.Net;
using MascaradeApp.WebAPI.DTO;
using MascaradeApp.WebAPI.Models;
using MascaradeApp.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MascaradeApp.WebAPI.Endpoints;

public static class AuthEndpoints
{
    public static void ConfigureAuthEndpoint(this WebApplication app)
    {
        // LOGIN
        app.MapPost("/api/login", Login)
            .WithName("Login")
            .Accepts<LoginRequestDTO>("application/json")
            .Produces<ApiResponse>(200)
            .Produces(400);
        // REGISTER
        app.MapPost("/api/register",Register)
            .WithName("Register")
            .Accepts<RegistrationRequestDTO>("application/json")
            .Produces<ApiResponse>(200)
            .Produces(400);
    }
    

    private static async Task<IResult> Login(IAuthRepository _authRepo,
        [FromBody] LoginRequestDTO model)
    {
        ApiResponse response = new()
        {
            IsSuccess = false,
            StatusCode = HttpStatusCode.BadRequest
        };
        
        var loginResponse = await _authRepo.Login(model);
        if (loginResponse is null)
        {
            response.ErrorMessages.Add("Username or password is incorrect.");
            return Results.BadRequest(response);
        }
        response.Result = loginResponse;
        response.IsSuccess = true;
        response.StatusCode = HttpStatusCode.OK;
        return Results.Ok(response);
    }

    private static async Task<IResult> Register(IAuthRepository _authRepo,
        [FromBody] RegistrationRequestDTO model)
    {
        ApiResponse response = new()
        {
            IsSuccess = false,
            StatusCode = HttpStatusCode.BadRequest
        };

        if (!_authRepo.IsUniqueUser(model.UserName))
        {
            response.ErrorMessages.Add("Username is already existed.");
            return Results.BadRequest(response);
        }
        
        var registerResponse = await _authRepo.Register(model);
        if (registerResponse is null || string.IsNullOrEmpty(registerResponse.UserName))
        {
            return Results.BadRequest(response);
        }
        
        response.IsSuccess = true;
        response.StatusCode = HttpStatusCode.OK;
        return Results.Ok(response);
    }
}