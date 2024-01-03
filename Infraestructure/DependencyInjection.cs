using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using SistemaPrayaga.Infraestructure;

namespace SistemaPrayaga.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionEntity");

            services.AddScoped<EntityInterceptor>();

            _ = services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            
            return services;
        }
    }
}