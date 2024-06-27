using backend_challenge.Modules.hero.useCases.create;
using backend_challenge.Modules.hero.repository;
using UnitTests.Helpers;

namespace backend_challenge.unitTests;

public class HeroCreateUseCaseTests
{
    [Fact]
    public async Task Exec_ShouldReturnCreatedHero_WhenCalledWithValidHero()
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
        var sut = new HeroCreateUseCase(_dbContext);

        // Act
        var result = await sut.exec(testHero);

        // Assert
        Assert.Equal(testHero.id, result.id);
        Assert.Equal(testHero.name, result.name);
        Assert.Equal(testHero.description, result.description);
        Assert.Equal(testHero.image, result.image);
    }

    [Fact]
    public async Task Exec_ShouldThrowException_WhenCalledWithInvalidHero()
    {
        // Arrange
        var testHero = new Hero
        {
            id = Guid.NewGuid(),
            name = null!,
            description = "Man of Steel",
            image = "superman.jpg"
        };

        await using var _dbContext = new MockDb().CreateDbContext();
        var sut = new HeroCreateUseCase(_dbContext);

        // Act and Assert
        var exception = await Assert.ThrowsAsync<Microsoft.EntityFrameworkCore.DbUpdateException>(() => sut.exec(testHero));
        Assert.Contains("Required properties '{'name'}' are missing for the instance of entity type 'Hero'", exception.Message);
    }
}