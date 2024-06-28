using backend_challenge.context;
using Namotion.Reflection;

namespace backend_challenge.Modules.hero.useCases.create;

public class HeroReadOneEndPoint : Endpoint<Request, Response, Mapper>
{
    public AppDbContext _dbContext { get; init; }

    public override void Configure()
    {
        Post("heroes");
        Summary(s =>
        {
            s.Summary = "Creates a new \"Hero\"";
            s.Description = "Register a \"Hero\" on the platform";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        try
        {
            var useCase = new HeroCreateUseCase(_dbContext);

            var mapper = new Mapper(_dbContext);

            var newHero = await mapper.ToEntityAsync(req, ct);

            var createdHero = await useCase.exec(newHero);

            var responseHero = mapper.FromEntity(createdHero);

            await SendAsync(responseHero);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}