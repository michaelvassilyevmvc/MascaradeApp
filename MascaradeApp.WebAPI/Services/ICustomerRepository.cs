using MascaradeApp.WebAPI.Entities;

namespace MascaradeApp.WebAPI.Services;

public interface ICustomerRepository
{
    Task<ICollection<Customer>> GetAllCustomersAsync();
    Task<Customer> GetAsync(int id);
    Task<Customer> GetAsync(string customerName);
    Task CreateAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    void Delete(Customer customer);
    Task SaveAsync();
}