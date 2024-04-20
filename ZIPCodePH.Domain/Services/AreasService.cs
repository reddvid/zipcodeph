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

    public async Task<IEnumerable<Area>> GetAreas()
    {
        return await _context.Areas!.Include("Group").ToArrayAsync();
    }

    public async Task<IEnumerable<Area>> GetAreasByGroupName(string name)
    {
        return await _context.Areas!.Include("Group").Where(a => a.Group.Name == name).ToArrayAsync();
    }
}