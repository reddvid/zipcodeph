using Microsoft.EntityFrameworkCore;
using ZIPCodePH.DataContext.Data;
using ZIPCodePH.DataContext.Entities;

namespace ZIPCodePH.DataContext.Services;

public class AreasService : IAreasService
{
    private readonly ApplicationContext _context;

    public AreasService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Area>> GetAreas() => await _context.Areas!.ToArrayAsync();

    public async Task<IEnumerable<Area>?> GetAreasByQuery(string name) =>
        await _context.Areas!
            .Where(a => a.Name.ToLower().Contains(name.ToLower()))
            .ToArrayAsync();
}