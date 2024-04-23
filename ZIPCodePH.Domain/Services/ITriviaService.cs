using ZIPCodePH.DataContext.Entities;

namespace ZIPCodePH.DataContext.Services;

public interface ITriviaService
{
    Task<IEnumerable<Trivia>> GetAll();
    Task<string> GetRandomTrivia();
}