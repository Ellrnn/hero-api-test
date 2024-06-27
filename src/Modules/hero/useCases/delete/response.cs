namespace backend_challenge.Modules.hero.useCases.delete;

public class Response
{
    public Guid id { get; set; }
    public string Message => "\"Hero\" deleted";
}