using backend_challenge.context;

namespace backend_challenge.Modules.hero.useCases.delete;

public class HeroDeleteEndpoint : Endpoint<Request, Response>
{
    public AppDbContext _dbContext { get; set; }

    public override void Configure()
    {
        Delete("heroes");
        Summary(s =>
        {
            s.Summary = "Removes a \"Hero\"";
            s.Description = "This will delete the \"Hero\"";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        try
        {
            var useCase = new HeroDeleteUseCase(_dbContext);

            int deletedRow = await useCase.exec(req.id);

            if (deletedRow == 0)
            {
                await SendNotFoundAsync();
                return;
            }

            Response.id = req.id;

            await SendAsync(Response);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
}