namespace backend_challenge.Modules.hero.useCases.update;

public class Request
{
    public Guid id { get; set; }
    public string name { get; set; } = null!;
    public string? description { get; set; }
    public string? image { get; set; }
}