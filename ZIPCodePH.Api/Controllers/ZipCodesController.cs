using Microsoft.AspNetCore.Mvc;
using X.PagedList;
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
    public async Task<IPagedList<ZipCode>> GetAll(int? page)
    {
        var zipCodes = await _zipCodesService.GetZipCodes();

        var pageNumber = page ?? 1;
        return zipCodes.ToPagedList(pageNumber, 10);
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
}