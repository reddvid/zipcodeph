using Microsoft.AspNetCore.Mvc;
using ZIPCodePH.DataContext.Entities;
using ZIPCodePH.DataContext.Services;

namespace ZIPCodePH.Api.Controllers;

[ApiController]
[Route("/")]
public class ZipCodesController : ControllerBase
{
    private readonly ILogger<ZipCodesController> _logger;
    private readonly IZipCodesService _zipCodesService;

    public ZipCodesController(ILogger<ZipCodesController> logger, IZipCodesService zipCodesService)
    {
        _logger = logger;
        _zipCodesService = zipCodesService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ZipCode>>> GetAll()
    {
        var zipCodes = await _zipCodesService.GetZipCodes();
        return zipCodes.ToArray();
    }

    [HttpGet("query")]
    public async Task<ActionResult<IEnumerable<ZipCode>>> GetZipCode(string query)
    {
        var zipCodes = await _zipCodesService.GetZipCodesByQuery(query);
        return zipCodes.ToArray();
    }
}