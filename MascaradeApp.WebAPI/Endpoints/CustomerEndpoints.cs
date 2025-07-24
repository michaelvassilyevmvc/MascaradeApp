using System.Net;
using AutoMapper;
using FluentValidation;
using MascaradeApp.WebAPI.DTO;
using MascaradeApp.WebAPI.Entities;
using MascaradeApp.WebAPI.Models;
using MascaradeApp.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MascaradeApp.WebAPI.Endpoints;

public static class CustomerEndpoints
{
    private static string url = "/api/customers";

    public static void ConfigureCustomerEndpoint(this WebApplication app)
    {
        // GET
        app.MapGet(url, GetAllCustomer)
            .WithName("GetAllCustomer")
            .Produces<ApiResponse>(201);

        // GET by ID
        app.MapGet(url + "/{id:int}", GetByIdCustomer)
            .WithName("GetByIdCustomer")
            .Produces<ApiResponse>(201);

        // POST
        app.MapPost(url, CreateCustomer)
            .WithName("CreateCustomer")
            .Accepts<CustomerCreateDto>("application/json")
            .Produces<ApiResponse>(201)
            .Produces(400);

        // PUT
        app.MapPut(url, UpdateCustomer)
            .WithName("UpdateCustomer")
            .Accepts<CustomerUpdateDto>("application/json")
            .Produces<ApiResponse>(201)
            .Produces(400);

        // DELETE 
        app.MapDelete(url + "/{id:int}", DeleteCustomer)
            .WithName("DeleteCustomer")
            .Produces<ApiResponse>(201)
            .Produces(400);
    }

    private static async Task<IResult> GetAllCustomer(ICustomerRepository _repo,
        ILogger<Program> _logger)
    {
        ApiResponse response = new();
        _logger.LogInformation("Get all Customers");
        response.Result = await _repo.GetAllCustomersAsync();
        response.IsSuccess = true;
        response.StatusCode = HttpStatusCode.OK;
        return Results.Ok(response);
    }

    private static async Task<IResult> GetByIdCustomer(ICustomerRepository _repo,
        ILogger<Program> _logger,
        int id)
    {
        ApiResponse response = new();
        _logger.LogInformation("Get Customer {id}");
        response.Result = await _repo.GetAsync(id);
        response.IsSuccess = true;
        response.StatusCode = HttpStatusCode.OK;
        return Results.Ok(response);
    }

    private static async Task<IResult> CreateCustomer(ICustomerRepository _repo,
        IMapper _mapper,
        ILogger<Program> _logger,
        IValidator<CustomerCreateDto> _validation,
        [FromBody] CustomerCreateDto customerCreateDto)
    {
        ApiResponse response = new()
        {
            IsSuccess = false,
            StatusCode = HttpStatusCode.BadRequest,
            ErrorMessages = new()
        };

        var validationResult = await _validation.ValidateAsync(customerCreateDto);
        if (!validationResult.IsValid)
        {
            response.ErrorMessages.AddRange(validationResult.Errors.Select(x => x.ErrorMessage.ToString()));
            return Results.BadRequest(response);
        }

        if (await _repo.GetAsync(customerCreateDto.FullName) is not null)
        {
            response.ErrorMessages.Add($"Customer '{customerCreateDto.FullName}' already exists.");
            return Results.BadRequest(response);
        }

        Customer customer = _mapper.Map<Customer>(customerCreateDto);
        customer.RegisteredAt = DateTime.UtcNow;
        await _repo.CreateAsync(customer);
        await _repo.SaveAsync();

        response.IsSuccess = true;
        response.Result = _mapper.Map<CustomerDto>(customer);
        response.StatusCode = HttpStatusCode.Created;
        return Results.Ok(response);
    }


    private static async Task<IResult> UpdateCustomer(ICustomerRepository _repo,
        ILogger<Program> logger,
        IMapper _mapper,
        IValidator<CustomerUpdateDto> validator, [FromBody] CustomerUpdateDto customerUpdateDto)
    {
        // Создаем шаблон ответа
        ApiResponse response = new()
        {
            IsSuccess = false,
            StatusCode = HttpStatusCode.BadRequest,
            ErrorMessages = new()
        };

        // Валидация модели
        var validationResult = validator.Validate(customerUpdateDto);
        if (!validationResult.IsValid)
        {
            response.ErrorMessages.AddRange(validationResult.Errors.Select(x => x.ErrorMessage.ToString()));
            response.StatusCode = HttpStatusCode.BadRequest;
            return Results.BadRequest(response);
        }

        // Проверка на существование по Id
        var customer = await _repo.GetAsync(customerUpdateDto.Id);
        if (customer is null)
        {
            response.ErrorMessages.Add($"Customer with {customer.Id} not exists.");
            response.StatusCode = HttpStatusCode.NotFound;
            return Results.NotFound(response);
        }

        // проверка на имя
        var customerName = await _repo.GetAsync(customerUpdateDto.FullName);
        if (customerName is not null && customerName.Id != customerUpdateDto.Id)
        {
            response.ErrorMessages.Add($"Customer with name {customerUpdateDto.FullName} not exists.");
            response.StatusCode = HttpStatusCode.NotFound;
            return Results.NotFound(response);
        }

        // Update через repo
        await _repo.UpdateAsync(_mapper.Map<Customer>(customerUpdateDto));
        await _repo.SaveAsync();

        // Заполнить шаблон ответа
        response.IsSuccess = true;
        response.StatusCode = HttpStatusCode.NoContent;
        response.Result = _mapper.Map<CustomerDto>(customerUpdateDto);

        return Results.Ok(response);
        ;
    }

    private static async Task<IResult> DeleteCustomer(ICustomerRepository _repo,
        ILogger<Program> logger,
        int id)
    {
        // Шаблон ответа
        ApiResponse response = new()
        {
            IsSuccess = false,
            StatusCode = HttpStatusCode.BadRequest,
            ErrorMessages = new()
        };

        // Проверка на существование по Id
        var customer = await _repo.GetAsync(id);
        if (customer is null)
        {
            response.ErrorMessages.Add($"Customer with {id} not exists.");
            response.StatusCode = HttpStatusCode.NotFound;
            return Results.NotFound(response);
        }

        // Delete через repo
        _repo.Delete(customer);
        await _repo.SaveAsync();

        // Заполнить шаблон ответа
        response.IsSuccess = true;
        response.StatusCode = HttpStatusCode.OK;
        return Results.Ok(response);
    }
}