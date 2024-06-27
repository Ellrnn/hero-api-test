using backend_challenge.context;
using backend_challenge.Modules.hero.repository;

namespace backend_challenge.Modules.hero.useCases.readOne;

public class HeroReadOneUseCase
{
    private readonly IHero _heroData;

    public HeroReadOneUseCase(AppDbContext _databaseContext)
    {
        _heroData = new HeroData(_databaseContext);
    }

    public async Task<Hero?> exec(Guid id)
    {
        var hero = await _heroData.readOne(id);

        return hero;
    }
}
