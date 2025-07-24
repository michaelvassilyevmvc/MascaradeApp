using MascaradeApp.WebAPI.Data;
using MascaradeApp.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace MascaradeApp.WebAPI.Services;

public class CostumeRepository : ICostumeRepository
{
    private readonly ApplicationDbContext _db;

    public CostumeRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<ICollection<Costume>> GetAllCostumesAsync() =>
        await _db.Costumes.AsNoTracking()
            .ToListAsync();

    public async Task<Costume> GetAsync(int id) => await _db.Costumes.AsNoTracking()
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Costume> GetAsync(string costumeName) => await _db.Costumes.AsNoTracking()
        .FirstOrDefaultAsync(x => x.Name.ToLower() == costumeName.ToLower());

    public async Task CreateAsync(Costume costume)
    {
        await _db.Costumes.AddAsync(costume);
    }

    public async Task UpdateAsync(Costume costume)
    {
        _db.Update(costume);
        await _db.SaveChangesAsync();
    }

    public void Delete(Costume costume)
    {
        _db.Costumes.Remove(costume);
    }

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}