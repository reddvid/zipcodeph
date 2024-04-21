using System.Text.Json.Serialization;

namespace ZIPCodePH.Common.Models;

public class TriviaModel
{
    [JsonPropertyName("trivia")] public IEnumerable<string>? Trivia { get; set; }
}