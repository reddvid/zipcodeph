using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using ZIPCodePH.DataContext.Entities;
using ZIPCodePH.DataContext.Services;

namespace ZIPCodePH.Api.Controllers;

[ApiController]
[Route("api/zipcodes")]
public class ZipCodeController : ControllerBase
{
    private readonly ILogger<ZipCodeController> _logger;
    private readonly IZipCodesService _zipCodesService;

    public ZipCodeController(ILogger<ZipCodeController> logger, IZipCodesService zipCodesService)
    {
        _logger = logger;
        _zipCodesService = zipCodesService;
    }

    [HttpGet]
    public async Task<IPagedList<ZipCode>> GetAll(int? page)
    {
        var zipCodes = await _zipCodesService.GetZipCodes();

        var pageNumber = page ?? 1;
        return zipCodes.ToPagedList(pageNumber, 10);
    }
    
    [HttpGet("all")]
    public async Task<IEnumerable<ZipCode>> GetAll()
    {
        var zipCodes = await _zipCodesService.GetZipCodes();
        return zipCodes.ToArray();
    }

    [HttpGet("q={query}")]
    public async Task<IPagedList<ZipCode>> GetZipCode(string query, int? page)
    {
        var zipCodes = await _zipCodesService.GetZipCodesByQuery(query);

        if (zipCodes.Count() > 10)
        {
            var pageNumber = page ?? 1;
            return zipCodes.ToPagedList(pageNumber, 10);
        }

        return zipCodes.ToPagedList();
    }

    [HttpGet("{area}")]
    public async Task<IEnumerable<ZipCode>> GetZipCodeByArea(string area)
    {
        var zipCodes = await _zipCodesService.GetZipCodesByArea(area);
        return zipCodes.ToArray();
    }
}