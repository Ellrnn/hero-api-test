using backend_challenge.context;
using backend_challenge.Modules.superpower.repository;
using backend_challenge.Modules.uniformColor.repository;

namespace backend_challenge.Modules.hero.repository;

public class HeroData : IHero
{
    private readonly AppDbContext _context;

    public HeroData(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<Hero> create(Hero entity)
    {
        _context.Heroes.Add(entity);

        var ret = await _context.SaveChangesAsync();

        Console.WriteLine(ret);

        return entity;
    }

    public async Task<List<HeroDto>> readList()
    {
        var query = _context.Heroes.Include(h => h.UniformColor).Include(h => h.Superpowers);
        var heroes = await query.ToListAsync();

            var heroDtos = heroes.Select(hero => new HeroDto
            {
                id = hero.id,
                name = hero.name,
                description = hero.description,
                image = hero.image,
                UniformColor = new UniformColorDto
                {
                    id = hero.UniformColor.id,
                    name = hero.UniformColor.name
                },
                SuperPowers = hero.Superpowers.Select(superpower => new SuperPowerDto 
                {
                    id = superpower.id,
                    name = superpower.name
                }).ToList()
            }).ToList();

        return heroDtos;
    }


    public async Task<Hero?> readOne(Guid id)
    {
        var hero = await _context.Heroes.FindAsync(id);

        return hero;
    }

    public async Task<Hero> update(Hero entity)
    {
        var hero = await _context.Heroes.FindAsync(entity.id);

        if (hero is null)
        {
            return null; 
        }

        _context.Entry(hero).CurrentValues.SetValues(entity);

        _ = await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<int> delete(Guid id)
    {
        var hero = await _context.Heroes.FindAsync(id);

        if (hero is null) return 0;

        _context.Heroes.Remove(hero);

        return await _context.SaveChangesAsync();
    }
}