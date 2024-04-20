using System.Text.Json.Serialization;
using ZIPCodePH.Common.Models;

namespace ZIPCodePH.Common.ViewModels;

public  class AreaViewModel
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("group")] public GroupViewModel GroupView { get; set; }
}