using backend_challenge.Modules.hero.useCases.delete;
using backend_challenge.Modules.hero.repository;
using UnitTests.Helpers;

namespace backend_challenge.unitTests;

public class HeroDeleteUseCaseTests
{
    [Fact]
    public async Task Exec_ShouldDeleteHero_WhenCalledWithValidId()
    {
        // Arrange
        var testHero = new Hero
        {
            id = Guid.NewGuid(),
            name = "Superman",
            description = "Man of Steel",
            image = "superman.jpg"
        };

        await using var _dbContext = new MockDb().CreateDbContext();

        await _dbContext.Heroes.AddAsync(testHero);
        await _dbContext.SaveChangesAsync();

        var sut = new HeroDeleteUseCase(_dbContext);

        // Act
        var result = await sut.exec(testHero.id);

        // Assert
        Assert.Equal(1, result);
        Assert.DoesNotContain(testHero, _dbContext.Heroes);
    }

    [Fact]
    public async Task Exec_ShouldNotDeleteAnyHero_WhenCalledWithInvalidId()
    {
        // Arrange
        var testHero = new Hero
        {
            id = Guid.NewGuid(),
            name = "Superman",
            description = "Man of Steel",
            image = "superman.jpg"
        };

        await using var _dbContext = new MockDb().CreateDbContext();

        await _dbContext.Heroes.AddAsync(testHero);
        await _dbContext.SaveChangesAsync();

        var sut = new HeroDeleteUseCase(_dbContext);

        var invalidId = Guid.NewGuid();

        // Act
        var result = await sut.exec(invalidId);

        // Assert
        Assert.Equal(0, result);
        Assert.Contains(testHero, _dbContext.Heroes);
    }
}