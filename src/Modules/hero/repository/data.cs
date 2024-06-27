using backend_challenge.context;

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

    public async Task<List<Hero>> readList()
    {
        var query = _context.Heroes;

        return await query.ToListAsync();
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