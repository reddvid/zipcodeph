using Microsoft.AspNetCore.Mvc;
using ZIPCodePH.DataContext.Entities;
using ZIPCodePH.DataContext.Services;

namespace ZIPCodePH.Api.Controllers;

[ApiController]
[Route("api/groups")]
public class GroupController : ControllerBase
{
    private readonly ILogger<GroupController> _logger;
    private readonly IGroupsService _groupsService;

    public GroupController(ILogger<GroupController> logger, IGroupsService groupsService)
    {
        _logger = logger;
        _groupsService = groupsService;
    }

    [HttpGet]
    public async Task<IEnumerable<Group>> GetAll()
    {
        var groups = await _groupsService.GetGroups();

        return groups.ToArray();
    }
}