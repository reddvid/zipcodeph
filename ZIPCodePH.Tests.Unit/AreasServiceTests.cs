using ZIPCodePH.DataContext.Services;
using ZIPCodePH.Tests.Unit.Fakes;

namespace ZIPCodePH.Tests.Unit;

public class AreasServiceTests : IDisposable
{
    private readonly ApplicationContextFakeBuilder _contextBuilder = new();
    private AreasService _sut;

    public void Dispose()
    {
        _contextBuilder.Dispose();
    }

    [Fact]
    public async Task GetAreas_WithSampleAreas_AllFourAreas()
    {
        // Arrange
        var ctx = _contextBuilder
            .WithFiveZipCodes()
            .Build();
        _sut = new AreasService(ctx);
        var expected = 4;

        // Act
        var areas = await _sut.GetAreas();
        var actual = areas.Count();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetAreas_WithSampleAreas_AllDistinctAreaNames()
    {
        // Arrange
        var ctx = _contextBuilder
            .WithFiveZipCodes()
            .Build();
        _sut = new AreasService(ctx);
        string[] expectedAreaNames = ["Manila", "Pangasinan", "Batangas", "Cebu"];

        // Act
        var areas = await _sut.GetAreas();
        var actualAreaNames = areas.Select(a => a.Name).ToArray();

        // Assert
        Assert.Equivalent(expectedAreaNames, actualAreaNames);
    }
}