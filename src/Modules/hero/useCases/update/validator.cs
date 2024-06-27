namespace backend_challenge.Modules.hero.useCases.update;

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(request => request.id)
            .NotEmpty()
            .WithMessage("Parameter \"id\" is required!");

        RuleFor(request => request.name)
            .NotEmpty()
            .WithMessage("Parameter \"name\" is required!");

        RuleFor(request => request.description)
            .NotEmpty()
            .WithMessage("Parameter \"description\" is required!");
    }
}
