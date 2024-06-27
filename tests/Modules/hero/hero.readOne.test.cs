using backend_challenge.Modules.hero.useCases.readOne;
using backend_challenge.Modules.hero.repository;
using UnitTests.Helpers;

namespace backend_challenge.unitTests;

public class HeroReadOneUseCaseTests
{
    [Fact]
    public async Task Exec_ShouldReturnHero_WhenCalledWithValidId()
    {
        // Arrange
        var testHero = new Hero
        {
            name = "Superman",
            description = "Man of Steel",
            image = "superman.jpg"
        };

        await using var _dbContext = new MockDb().CreateDbContext();

        var createdHero = await _dbContext.Heroes.AddAsync(testHero);
        await _dbContext.SaveChangesAsync();

        var sut = new HeroReadOneUseCase(_dbContext);

        // Act
        var result = await sut.exec(createdHero.Entity.id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(testHero.name, result.name);
        Assert.Equal(testHero.description, result.description);
        Assert.Equal(testHero.image, result.image);
    }

    [Fact]
    public async Task Exec_ShouldReturnNull_WhenCalledWithInvalidId()
    {
        // Arrange
        var invalidId = Guid.NewGuid();

        var testHero = new Hero
        {
            id = Guid.NewGuid(),
            name = "Superman",
            description = "Man of Steel",
            image = "superman.jpg"
        };

        await using var _dbContext = new MockDb().CreateDbContext();

        var createdHero = await _dbContext.Heroes.AddAsync(testHero);
        await _dbContext.SaveChangesAsync();

        var sut = new HeroReadOneUseCase(_dbContext);

        // Act
        var result = await sut.exec(invalidId);

        // Assert
        Assert.Null(result);
    }
}