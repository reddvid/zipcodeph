using System.Runtime.InteropServices;
using ZIPCodePH.DataContext.Services;
using ZIPCodePH.Tests.Unit.Fakes;

namespace ZIPCodePH.Tests.Unit;

public class ZipCodesServiceTests : IDisposable
{
    private readonly ApplicationContextFakeBuilder _contextBuilder = new();
    private ZipCodesService _sut;

    public void Dispose()
    {
        _contextBuilder.Dispose();
    }

    [Fact]
    public async Task GetZipCodes_NoZipCodesInDB_NoZipCodes()
    {
        // Arrange
        var ctx = _contextBuilder.Build();
        _sut = new ZipCodesService(ctx);

        // Act
        var actual = await _sut.GetZipCodes();

        // Assert
        Assert.True(!actual.Any());
    }

    [Fact]
    public async Task GetZipCodes_OneZipCodeInDB_OneZipCode()
    {
        // Arrange
        var ctx = _contextBuilder
            .WithOneZipCode()
            .Build();
        _sut = new ZipCodesService(ctx);
        var expected = 1;

        // Act
        var actual = await _sut.GetZipCodes();

        // Assert
        Assert.Equal(expected, actual.Count());
    }

    [Fact]
    public async Task GetZipCodes_OneAreaInDB_AreaName()
    {
        // Arrange
        var ctx = _contextBuilder
            .WithOneZipCode()
            .Build();
        _sut = new ZipCodesService(ctx);
        var expected = "Manila";

        // Act
        var zips = await _sut.GetZipCodes();
        var actual = zips.SingleOrDefault()!.Area.Name;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetZipCodes_OneTownInDB_TownName()
    {
        // Arrange
        var ctx = _contextBuilder
            .WithOneZipCode()
            .Build();
        _sut = new ZipCodesService(ctx);
        var expected = "Culiat";

        // Act
        var zips = await _sut.GetZipCodes();
        var actual = zips.SingleOrDefault()!.Town;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task GetZipCodes_OneZipCodeInDb_ZipCodeNumber()
    {
        // Arrange
        var ctx = _contextBuilder
            .WithOneZipCode()
            .Build();
        _sut = new ZipCodesService(ctx);
        var expected = 1128;

        // Act
        var zips = await _sut.GetZipCodes();
        var actual = zips.SingleOrDefault()!.Code;

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("")]
    [InlineData("  ")]
    public async Task GetZipCodesByQuery_QueryIsInvalid_ArgumentException(string query)
    {
        // Arrange
        var ctx = _contextBuilder.Build();
        _sut = new ZipCodesService(ctx);

        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(
            () => _sut.GetZipCodesByQuery(query));

        // Assert
        Assert.IsType<ArgumentException>(exception);
    }

    [Theory]
    [InlineData("Manila", 2)]
    [InlineData("Batangas", 1)]
    [InlineData("Calasiao", 1)]
    [InlineData("Cebu", 1)]
    public async Task GetZipCodesByQuery_HasQuery_ZipCodes(string query, int expectedCount)
    {
        // Arrange
        var ctx = _contextBuilder
            .WithFiveZipCodes()
            .Build();
        _sut = new ZipCodesService(ctx);
        
        // Act
        var zips = await _sut.GetZipCodesByQuery(query);
        var actual = zips.Count();

        // Assert
        Assert.Equal(expectedCount, actual);
    }

    [Theory]
    [InlineData("Rosario", 3)]
    [InlineData("Ca", 2)]
    [InlineData("xzcasd", 0)]
    public async Task GetZipCodesByQuery_HasQuery_AreasContainingQueryCount(string query, int expectedCount)
    {
        // Arrange
        var ctx = _contextBuilder
            .WithFiveZipCodes()
            .WithContainingNames()
            .Build();
        _sut = new ZipCodesService(ctx);
        // Act
        var zips = await _sut.GetZipCodesByQuery(query);
        var actual = zips.Count();
        
        // Assert
        Assert.Equal(expectedCount, actual);
    }
}