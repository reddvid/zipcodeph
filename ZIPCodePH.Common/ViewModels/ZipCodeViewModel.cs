using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZIPCodePH.Common.ViewModels;

public class ZipCodeViewModel
{
    [JsonPropertyName("code")] public int Code { get; set; }
    [JsonPropertyName("town")] public string? Town { get; set; }
    [JsonPropertyName("area")] public AreaViewModel? Area { get; set; }
}