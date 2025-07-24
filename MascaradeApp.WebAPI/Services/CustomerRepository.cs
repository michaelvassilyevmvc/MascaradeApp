using MascaradeApp.WebAPI.Data;
using MascaradeApp.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace MascaradeApp.WebAPI.Services;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _db;

    public CustomerRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ICollection<Customer>> GetAllCustomersAsync() =>
        await _db.Customers.AsNoTracking()
            .ToListAsync();

    public async Task<Customer> GetAsync(int id) => await _db.Customers.AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Customer> GetAsync(string customerName) => await _db.Customers.AsNoTracking()
        .FirstOrDefaultAsync(x => x.FullName.ToLower() == customerName.ToLower());

    public async Task CreateAsync(Customer customer)
    {
        await _db.Customers.AddAsync(customer);
    }

    public async Task UpdateAsync(Customer customer)
    {
        _db.Update(customer);
        await _db.SaveChangesAsync();
    }

    public void Delete(Customer customer)
    {
        _db.Customers.Remove(customer);
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}