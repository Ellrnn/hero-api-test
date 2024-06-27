using backend_challenge.context;
using backend_challenge.Modules.hero.repository;

namespace backend_challenge.Modules.hero.useCases.create;

public class HeroCreateUseCase
{
    private readonly IHero _heroData;

    public HeroCreateUseCase(AppDbContext _databaseContext)
    {
        _heroData = new HeroData(_databaseContext);
    }

    public async Task<Hero> exec(Hero entity)
    {
        var createdHero = await _heroData.create(entity);

        return createdHero;
    }
}
