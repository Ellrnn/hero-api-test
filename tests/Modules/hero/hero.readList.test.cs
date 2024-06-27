using backend_challenge.Modules.hero.useCases.readList;
using backend_challenge.Modules.hero.repository;
using UnitTests.Helpers;

namespace backend_challenge.unitTests;

public class HeroReadListUseCaseTests
{
    [Fact]
    public async Task Exec_ShouldReturnListOfHeroes_WhenCalled()
    {
        // Arrange
        var testHeroes = new List<Hero>
        {
            new Hero
            {
                id = Guid.NewGuid(),
                name = "Superman",
                description = "Man of Steel",
                image = "superman.jpg"
            },
            new Hero
            {
                id = Guid.NewGuid(),
                name = "Batman",
                description = "The Dark Knight",
                image = "batman.jpg"
            },
        };

        await using var _dbContext = new MockDb().CreateDbContext();

        await _dbContext.Heroes.AddRangeAsync(testHeroes);
        await _dbContext.SaveChangesAsync();

        var sut = new HeroReadListUseCase(_dbContext);

        // Act
        var result = await sut.exec();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(testHeroes.Count, result.Count);

        Assert.Collection(result,
            hero => 
            {
                Assert.Equal(testHeroes[0].name, hero.name);
                Assert.Equal(testHeroes[0].description, hero.description);
                Assert.Equal(testHeroes[0].image, hero.image);
            },
            hero => 
            {
                Assert.Equal(testHeroes[1].name, hero.name);
                Assert.Equal(testHeroes[1].description, hero.description);
                Assert.Equal(testHeroes[1].image, hero.image);
            }
        );
    }
}