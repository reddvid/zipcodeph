using System.Text.Json.Serialization;

namespace ZIPCodePH.Common.Models;

public class TriviaModel
{
    [JsonPropertyName("record")] public IEnumerable<string>? Trivia { get; set; }
}