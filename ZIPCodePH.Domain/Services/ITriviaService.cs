namespace ZIPCodePH.DataContext.Services;

public interface ITriviaService
{
    //Task<IEnumerable<string>> GetAll();
    Task<string> GetRandomTrivia();
}