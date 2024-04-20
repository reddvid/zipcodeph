using ZIPCodePH.DataContext.Entities;

namespace ZIPCodePH.DataContext.Services;

public interface IAreasService
{
    Task<IEnumerable<Area>> GetAreas();
    
    Task<IEnumerable<Area>> GetAreasByGroupName(string name);
}