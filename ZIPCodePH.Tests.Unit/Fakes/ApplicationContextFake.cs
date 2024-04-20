using Microsoft.EntityFrameworkCore;
using ZIPCodePH.DataContext.Data;

namespace ZIPCodePH.Tests.Unit.Fakes;

public class ApplicationContextFake : ApplicationContext
{
    public ApplicationContextFake() : base(new DbContextOptionsBuilder<ApplicationContext>()
        .UseInMemoryDatabase($"ZipCodePHTest={Guid.NewGuid()}").Options)
    {
    }
}