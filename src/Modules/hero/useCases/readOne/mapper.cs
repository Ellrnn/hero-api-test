using backend_challenge.Modules.hero.repository;

namespace backend_challenge.Modules.hero.useCases.readOne;

public class Mapper : ResponseMapper<Response, Hero>
{
    public override Response FromEntity(Hero entity) => new()
    {
        id = entity.id,
        name = entity.name,
        description = entity.description,
        image = entity.image
    };
}
