using backend_challenge.Modules.hero.repository;

namespace backend_challenge.Modules.uniformColor.repository;

public class UniformColor
{
    public Guid id { get; set; }
    public string name { get; set; } = null!;
    public ICollection<Hero> Heroes {get; set;}

}