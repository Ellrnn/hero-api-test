using backend_challenge.context;
using backend_challenge.Modules.hero.repository;

namespace backend_challenge.Modules.hero.useCases.delete;

public class HeroDeleteUseCase
{
    private readonly IHero _heroData;

    public HeroDeleteUseCase(AppDbContext _databaseContext)
    {
        _heroData = new HeroData(_databaseContext);
    }

    public async Task<int> exec(Guid id)
    {
        return await _heroData.delete(id);
    }
}
