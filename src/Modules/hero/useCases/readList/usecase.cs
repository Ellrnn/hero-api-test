using backend_challenge.context;
using backend_challenge.Modules.hero.repository;

namespace backend_challenge.Modules.hero.useCases.readList;

public class HeroReadListUseCase
{
    private readonly IHero _data;

    public HeroReadListUseCase(AppDbContext _context)
    {
        _data = new HeroData(_context);
    }

    public async Task<List<Hero>> exec()
    {
        return await _data.readList();
    }
}