using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SistemaPrayaga.Domain;

namespace SistemaPrayaga.Infraestructure
{
    public class EntityInterceptor : SaveChangesInterceptor
    {
        public EntityInterceptor()
        {
        }

        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public void UpdateEntities(DbContext context)
        {
            if (context == null) return;

            foreach (var entry in context.ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.creado_tmstp = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.actualizado_tmstp = DateTime.Now;
                        break;

                }
            }
        }
    }
}