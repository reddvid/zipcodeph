using System.Text.Json.Serialization;

namespace ZIPCodePH.Common.ViewModels;

public class GroupViewModel
{
    [JsonPropertyName("name")] public string? Name { get; set; }
}