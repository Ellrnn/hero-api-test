namespace backend_challenge.Modules.hero.useCases.delete;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(request => request.id)
            .NotEmpty()
            .WithMessage("Parameter \"id\" is required!!");
    }
}