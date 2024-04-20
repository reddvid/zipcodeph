using ZIPCodePH.DataContext.Services;
using ZIPCodePH.Tests.Unit.Fakes;

namespace ZIPCodePH.Tests.Unit;

public class GroupsServiceTests : IDisposable
{
    private readonly ApplicationContextFakeBuilder _contextBuilder = new();
    private GroupsService _sut;
    
    public void Dispose()
    {
        _contextBuilder.Dispose();
    }

    [Fact]
    public async Task GetGroups_WithSampleAreas_DistinctGroupNames()
    {
        // Arrange
        var ctx = _contextBuilder
            .WithAllFourGroups()
            .Build();
        _sut = new GroupsService(ctx);
        string[] expectedGroupNames = ["NCR", "Luzon", "Visayas", "Mindanao"];

        // Act
        var groups = await _sut.GetGroups();
        var actualGroupNames = groups.Select(g => g.Name).ToArray();

        // Assert
        Assert.Equivalent(expectedGroupNames, actualGroupNames);
    }

    [Fact]
    public async Task GetGroups_WithAllFourGroups_AllFourGroups()
    {
        // Arrange
        var ctx = _contextBuilder
            .WithAllFourGroups()
            .Build();
        _sut = new GroupsService(ctx);
        var expected = 4;
        
        // Act
        var groups = await _sut.GetGroups();
        var actual = groups.Count();

        // Assert
        Assert.Equal(expected, actual);
    }
}