using Microsoft.EntityFrameworkCore;
using ZIPCodePH.DataContext.Data;
using ZIPCodePH.DataContext.Entities;

namespace ZIPCodePH.DataContext.Services;

public class ZipCodesService : IZipCodesService
{
    private readonly ApplicationContext _context;

    public ZipCodesService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ZipCode>> GetZipCodes() =>
        await _context.ZipCodes!.Include("Area").Include("Area.Group").ToArrayAsync();

    public async Task<IEnumerable<ZipCode>> GetZipCodesByArea(string area)
    {
        return await _context.ZipCodes!
            .Include("Area")
            .Include("Area.Group")
            .Where(
                z => z.Area.Name.ToLower()
                    .Contains(area.ToLower()))
            .ToArrayAsync();
    }
}