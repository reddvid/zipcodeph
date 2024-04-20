using System.Text.Json.Serialization;

namespace ZIPCodePH.Common.ViewModels;

public class TriviaViewModel
{
    [JsonPropertyName("trivia")] public IEnumerable<string>? Trivia { get; set; }
}