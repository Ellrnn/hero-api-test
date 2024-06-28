using backend_challenge.Modules.hero.repository;
using backend_challenge.context;
using backend_challenge.Modules.uniformColor.repository;
using backend_challenge.Modules.superpower.repository;

namespace backend_challenge.Modules.hero.useCases.create;

public class Mapper : Mapper<Request, Response, Hero>
{
    private readonly AppDbContext _dbContext;

    public Mapper(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<Hero> ToEntityAsync(Request req, CancellationToken ct)
    {
        var uniformColor = await _dbContext.UniformColors.FirstOrDefaultAsync(uc => uc.name == req.uniformColorName);
        var superpowers = await _dbContext.SuperPowers.Where(sp => req.superpowers.Contains(sp.name)).ToListAsync();

        if (uniformColor is null)
        {
            throw new Exception($"Uniform color '{req.uniformColorName}' not found");
        }

        if (superpowers is null)
        {
            throw new Exception($"Uniform color '{req.superpowers}' not found");
        }

        var hero = new Hero
        {
            name = req.name,
            description = req.description,
            image = req.image,
            UniformColorId = uniformColor.id,
            UniformColor = uniformColor,
            Superpowers = superpowers
        };

        return hero;
    }

    public override Response FromEntity(Hero entity)
    {
        return new Response
        {
            id = entity.id,
            name = entity.name,
            description = entity.description,
            image = entity.image,
            UniformColor = new UniformColorDto {
                id = entity.UniformColor.id,
                name = entity.UniformColor.name
            },
            SuperPowers = entity.Superpowers.Select(sp => new SuperPowerDto {
                id = sp.id,
                name = sp.name
            }).ToList()
        };
    }
}
