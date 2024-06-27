namespace backend_challenge.Modules.hero.repository;

public interface IHero
{
    Task<Hero> create(Hero entity);
    Task<Hero?> readOne(Guid id);
    Task<List<Hero>> readList();
    Task<Hero> update(Hero entity);
    Task<int> delete(Guid id);
}