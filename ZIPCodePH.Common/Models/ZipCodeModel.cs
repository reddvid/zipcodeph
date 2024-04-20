using System.Text.Json.Serialization;

namespace ZIPCodePH.Common.Models;

public class ZipCodeModel
{
    [JsonPropertyName("code")] public int Code { get; set; }
    [JsonPropertyName("town")] public string? Town { get; set; }
    [JsonPropertyName("area")] public AreaModel? Area { get; set; }
    public string ZipCode { get; set; }
    public string TownName { get; set; }
    public string AreaName { get; set; }

    public ZipCodeModel(string town, string zipCode, string area)
    {
        ZipCode = zipCode;
        TownName = town;
        AreaName = area;
    }
}