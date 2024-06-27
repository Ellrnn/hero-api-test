namespace backend_challenge.Modules.hero.useCases.create;

public class Request
{
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
    public string? image { get; set; }
}