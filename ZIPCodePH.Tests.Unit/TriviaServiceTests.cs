using ZIPCodePH.DataContext.Services;
using ZIPCodePH.Tests.Unit.Fakes;

namespace ZIPCodePH.Tests.Unit;

public class TriviaServiceTests : IDisposable
{
    private readonly ApplicationContextFakeBuilder _contextBuilder = new();
    private TriviaService _sut;

    public void Dispose()
    {
        _contextBuilder.Dispose();
    }

    [Fact]
    public async Task GetRandomTrivia_WithThreeTrivia_OneTrivia()
    {
        // Arrange
        var ctx = _contextBuilder
            .WithThreeTrivia()
            .Build();
        _sut = new TriviaService(null!, ctx);

        // Act
        var trivia = await _sut.GetRandomTrivia();

        // Assert
        Assert.NotNull(trivia);
        Assert.Contains("Trivia", trivia);
    }

    [Fact]
    public async Task GetRandomTrivia_WithNoTrivia_NullReferenceException()
    {
        // Arrange
        var ctx = _contextBuilder.Build();
        _sut = new TriviaService(null!, ctx);

        // Act
        var exception = await Assert.ThrowsAsync<NullReferenceException>(
            () => _sut.GetRandomTrivia());

        // Assert
        Assert.IsType<NullReferenceException>(exception);
    }
}