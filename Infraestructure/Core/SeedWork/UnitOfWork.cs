using SistemaPrayaga.Domain;

namespace SistemaPrayaga.Infraestructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<int> SaveEntitiesAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();

        public IRepository<T> Repository<T>() where T : Entity
        {
            return new Repository<T>(_context);
        }
    }
}