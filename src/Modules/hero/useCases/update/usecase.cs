using backend_challenge.context;
using backend_challenge.Modules.hero.repository;

namespace backend_challenge.Modules.hero.useCases.update;

public class HeroUpdateUseCase
{
    private readonly IHero _heroData;

    public HeroUpdateUseCase(AppDbContext _databaseContext)
    {
        _heroData = new HeroData(_databaseContext);
    }

    public async Task<Hero> exec(Hero entity)
    {
        var heroUpdated = await _heroData.update(entity);

        return heroUpdated;
    }
}