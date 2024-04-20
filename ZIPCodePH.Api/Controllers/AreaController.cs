using Microsoft.AspNetCore.Mvc;
using ZIPCodePH.DataContext.Entities;
using ZIPCodePH.DataContext.Services;

namespace ZIPCodePH.Api.Controllers;

[Route("/areas")]
public class AreaController : ControllerBase
{
    private readonly ILogger<AreaController> _logger;
    private readonly IAreasService _areasService;

    public AreaController(ILogger<AreaController> logger, IAreasService areasService)
    {
        _logger = logger;
        _areasService = areasService;
    }

    [HttpGet("/areas={groupName}")]
    public async Task<IEnumerable<Area>> GetAreasByGroupName(string groupName)
    {
        var areas = await _areasService.GetAreasByGroupName(groupName);
        return areas.ToArray();
    }
    
    [HttpGet]
    public async Task<IEnumerable<Area>> GetAll()
    {
        var areas = await _areasService.GetAreas();
        return areas.ToArray();
    }
}