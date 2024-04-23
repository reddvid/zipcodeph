using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ZIPCodePH.Common.Models;
using ZIPCodePH.Common.ViewModels;
using ZIPCodePH.DataContext.Database;
using ZIPCodePH.DataContext.Entities;
using ZIPCodePH.DataContext.Options;

namespace ZIPCodePH.DataContext.Services;

public class TriviaService : ITriviaService
{
    private readonly ApplicationContext _context;

    public TriviaService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Trivia>> GetAll()
    {
        var trivia = await _context.Trivia!.ToArrayAsync();
        
        if (trivia is null || trivia.Length == 0)
        {
            throw new NullReferenceException("No Trivia found");
        }
        
        return trivia.ToArray();
    }

    public async Task<string> GetRandomTrivia()
    {
        // var trivia = await GetAllAsync();
        var trivia = await _context.Trivia!.ToArrayAsync();

        if (trivia is null || trivia.Length == 0)
        {
            throw new NullReferenceException("No Trivia found");
        }
        
        var i = Random.Shared.Next(0, trivia.Length);
        return trivia[i].Content;
    }
}