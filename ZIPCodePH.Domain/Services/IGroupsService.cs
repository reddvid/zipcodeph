using ZIPCodePH.DataContext.Entities;

namespace ZIPCodePH.DataContext.Services;

public interface IGroupsService
{
    Task<IEnumerable<Group>> GetGroups();
}