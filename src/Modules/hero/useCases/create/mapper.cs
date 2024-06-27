using backend_challenge.Modules.hero.repository;

namespace backend_challenge.Modules.hero.useCases.create;

public class Mapper : Mapper<Request, Response, Hero>
{
    public override Hero ToEntity(Request req) => new()
    {
        name = req.name,
        description = req.description,
        image = req.image
    };

    public override Response FromEntity(Hero entity) => new()
    {
        id = entity.id,
        name = entity.name,
        description = entity.description,
        image = entity.image
    };
}

