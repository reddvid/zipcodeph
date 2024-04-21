using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using ZIPCodePH.Common.ViewModels;

namespace ZIPCodePH.Common.Models;

public class ZipCodeModel
{
    public string ZipCode { get; set; }
    public string Town { get; set; }
    public string Area { get; set; }

    public ZipCodeModel(string town, string zipCode, string area)
    {
        ZipCode = zipCode;
        Town = town;
        Area = area;
    }
}