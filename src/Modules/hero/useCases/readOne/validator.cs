namespace backend_challenge.Modules.hero.useCases.readOne;

public class Validator : Validator<Request>
{
    public Validator()
    {
       RuleFor(request => request.id)
            .NotEmpty()
            .WithMessage("Parameter \"id\" is required!");
    }
}
