using SistemaPrayaga.Domain;

namespace SistemaPrayaga.Infraestructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : Entity;
        Task<int> SaveEntitiesAsync();
    }
}