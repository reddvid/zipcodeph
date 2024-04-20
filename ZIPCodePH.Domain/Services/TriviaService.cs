using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ZIPCodePH.Common.Models;
using ZIPCodePH.DataContext.Options;

namespace ZIPCodePH.DataContext.Services;

public class TriviaService : ITriviaService
{
    private readonly JsonBinConnectionOptions _connectionOptions;

    public TriviaService(IOptions<JsonBinConnectionOptions> connectionOptions)
    {
        _connectionOptions = connectionOptions.Value;
    }
    
    private async Task<IEnumerable<string>> GetAllAsync()
    {
        TriviaModel trivia = new();
        
        HttpClient client = new();
        client.DefaultRequestHeaders.Add("X-Master-Key", _connectionOptions.MasterKey);
        client.DefaultRequestHeaders.Add("X-Access-Key", _connectionOptions.AccessKey);
        var request = new HttpRequestMessage(HttpMethod.Get,
            "https://api.jsonbin.io/v3/b/6624061cad19ca34f85d61f1");
        var response = await client.SendAsync(request);

        Console.WriteLine(response.IsSuccessStatusCode);

        if (response.IsSuccessStatusCode)
        {
            await using var responseStream = await response.Content.ReadAsStreamAsync();
            trivia = await JsonSerializer.DeserializeAsync<TriviaModel>(responseStream);
        }

        return trivia.Trivia;
    }

    public async Task<string> GetRandomTrivia()
    {
        var trivia = await GetAllAsync();
        var i = Random.Shared.Next(0, trivia.Count());
        return trivia.ToArray()[i];

    }
}