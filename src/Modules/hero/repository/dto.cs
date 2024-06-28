using backend_challenge.Modules.superpower.repository;
using backend_challenge.Modules.uniformColor.repository;

namespace backend_challenge.Modules.hero.repository;

public class HeroDto
{
    public Guid id { get; set; }
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
    public string image { get; set; } = null!;
    public UniformColorDto UniformColor { get; set; }
    public List<SuperPowerDto> SuperPowers { get; set; }
}
