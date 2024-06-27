using backend_challenge.Modules.hero.useCases.update;
using backend_challenge.Modules.hero.repository;
using UnitTests.Helpers;

namespace backend_challenge.unitTests;

public class HeroUpdateUseCaseTests
{
    [Fact]
    public async Task Exec_ShouldReturnUpdatedHero_WhenCalledWithValidHero()
    {
        // Arrange
        var testHero = new Hero
        {
            name = "Superman",
            description = "Man of Steel",
            image = "superman.jpg"
        };

        await using var _dbContext = new MockDb().CreateDbContext();

        await _dbContext.Heroes.AddAsync(testHero);
        await _dbContext.SaveChangesAsync();

        var sut = new HeroUpdateUseCase(_dbContext);

        // Modificar a entidade
        testHero.name = "Batman";
        testHero.description = "The Dark Knight";
        testHero.image = "batman.jpg";

        // Act
        var result = await sut.exec(testHero);

        // Assert
        Assert.Equal(testHero.id, result.id);
        Assert.Equal(testHero.name, result.name);
        Assert.Equal(testHero.description, result.description);
        Assert.Equal(testHero.image, result.image);
    }
}