using System.Text.Json.Serialization;

namespace ZIPCodePH.Common.Models;

public class GroupModel
{
    [JsonPropertyName("name")] public string? Name { get; set; }
}