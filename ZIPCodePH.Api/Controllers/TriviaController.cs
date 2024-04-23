using Microsoft.AspNetCore.Mvc;
using ZIPCodePH.DataContext.Entities;
using ZIPCodePH.DataContext.Services;

namespace ZIPCodePH.Api.Controllers;

[ApiController]
[Route("api/trivia")]
public class TriviaController : ControllerBase
{
    private readonly ILogger<TriviaController> _logger;
    private readonly ITriviaService _triviaService;

    public TriviaController(ILogger<TriviaController> logger, ITriviaService triviaService)
    {
        _logger = logger;
        _triviaService = triviaService;
    }

    [HttpGet]
    public async Task<IEnumerable<Trivia>> GetAll()
    {
        var trivia = await _triviaService.GetAll();
        return trivia.ToArray();
    }


    [HttpGet("random")]
    public async Task<string> GetRandom()
    {
        var trivia = await _triviaService.GetRandomTrivia();
        return trivia;
    }
}