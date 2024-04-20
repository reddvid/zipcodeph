using System.Text.Json.Serialization;

namespace ZIPCodePH.Common.Models;

public  class AreaModel
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("group")] public GroupModel Group { get; set; }
}