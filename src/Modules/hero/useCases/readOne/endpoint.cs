using backend_challenge.context;

namespace backend_challenge.Modules.hero.useCases.readOne;

public class HeroReadOneEndPoint : Endpoint<Request, Response, Mapper>
{
    public AppDbContext _dbContext { get; init; }

    public override void Configure()
    {
        Get("heroes/{id}");
        Summary(s =>
        {
            s.Summary = "Gets a single \"Hero\" by it's id";
            s.Description = "Retrieves a \"Hero\" data by the id property.";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        try
        {
            Guid id = req.id;

            var useCase = new HeroReadOneUseCase(_dbContext);
            var hero = await useCase.exec(id);

            if (hero is null)
            {
                await SendNoContentAsync(ct);
                return;
            }

            var response = Map.FromEntity(hero);

            await SendAsync(response);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}