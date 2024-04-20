using Microsoft.EntityFrameworkCore;
using ZIPCodePH.DataContext.Data;
using ZIPCodePH.DataContext.Entities;

namespace ZIPCodePH.DataContext.Services;

public class GroupsService : IGroupsService
{
    private readonly ApplicationContext _context;

    public GroupsService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Group>> GetGroups() => await _context.Groups!.ToArrayAsync();
}