using MascaradeApp.WebAPI.Entities;

namespace MascaradeApp.WebAPI.Services;

public interface ICostumeRepository
{
    Task<ICollection<Costume>> GetAllCostumesAsync();
    Task<Costume> GetAsync(int id);
    Task<Costume> GetAsync(string costumeName);
    Task CreateAsync(Costume costume);
    Task UpdateAsync(Costume costume);
    void Delete(Costume costume);
    Task SaveAsync();
}