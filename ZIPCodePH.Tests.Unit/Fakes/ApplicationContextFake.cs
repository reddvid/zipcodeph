using Microsoft.EntityFrameworkCore;
using ZIPCodePH.DataContext.Database;

namespace ZIPCodePH.Tests.Unit.Fakes;

public class ApplicationContextFake : ApplicationContext
{
    public ApplicationContextFake() : base(new DbContextOptionsBuilder<ApplicationContext>()
        .UseInMemoryDatabase($"ZipCodePHTest={Guid.NewGuid()}").Options)
    {
    }
}