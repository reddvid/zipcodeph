using ZIPCodePH.DataContext.Entities;

namespace ZIPCodePH.DataContext.Services;

public interface IZipCodesService
{
    Task<IEnumerable<ZipCode>> GetZipCodes();

    Task<IEnumerable<ZipCode>> GetZipCodesByQuery(string query);
    
    Task<IEnumerable<ZipCode>> GetZipCodesByArea(string area);

}