using Microsoft.EntityFrameworkCore;
using ZIPCodePH.DataContext.Database;
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

    public async Task<IEnumerable<ZipCode>> GetZipCodesByQuery(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentException("Query is empty", nameof(query));
        }
        
        return await _context.ZipCodes!
            .Include("Area")
            .Include("Area.Group")
            .Where(
                z =>
                    z.Area.Name.ToLower().Contains(query.ToLower()) ||
                    z.Town.ToLower().Contains(query.ToLower()))
            .ToArrayAsync();
    }

    public async Task<IEnumerable<ZipCode>> GetZipCodesByArea(string area)
    {
        if (string.IsNullOrWhiteSpace(area))
        {
            throw new ArgumentException("Query is empty", nameof(area));
        }
        
        return await _context.ZipCodes!
            .Include("Area")
            .Include("Area.Group")
            .Where(
                z =>
                    z.Area.Name.ToLower().Equals(area.ToLower()))
            .ToArrayAsync();
    }
}