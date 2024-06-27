using backend_challenge.context;
using backend_challenge.Modules.hero.repository;

namespace backend_challenge.Modules.hero.useCases.readList;

public class HeroReadListEndPoint : EndpointWithoutRequest<List<Hero>>
{
    public AppDbContext _dbContext { get; set; }

    public override void Configure()
    {
        Get("heroes");
        Summary(s =>
        {
            s.Summary = "List heroes";
            s.Description = "Gets the list of heroes.";
        });
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var useCase = new HeroReadListUseCase(_dbContext);
            var response = await useCase.exec();
          
            await SendAsync(response);
        }
        catch (Exception e)
        {
            ThrowError(e.Message);
        }
    }
    
}