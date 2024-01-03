namespace SistemaPrayaga.Infraestructure
{
    using Microsoft.EntityFrameworkCore;
    using SistemaPrayaga.Domain;
    public class ApplicationDbContext : DbContext
    {
        private readonly EntityInterceptor _entityInterceptor;
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            EntityInterceptor entityInterceptor
            ) : base(options)
        {
            _entityInterceptor = entityInterceptor ?? throw new ArgumentNullException(nameof(entityInterceptor));
        }

        #region Facultad

        public DbSet<Facultad> Facultades { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_entityInterceptor);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Facultad

            modelBuilder.ApplyConfiguration(new FacultadConfiguration());
            modelBuilder.ApplyConfiguration(new CarreraConfiguration());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}