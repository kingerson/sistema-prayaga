using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPrayaga.Domain;

namespace SistemaPrayaga.Infraestructure
{
    public abstract class EntityMapBase<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        void IEntityTypeConfiguration<T>.Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(b => b.id);
            builder.Property(b => b.creado_tmstp).IsRequired();
            builder.Property(b => b.actualizado_tmstp).IsRequired(false);
            builder.Property(b => b.es_activo).HasDefaultValue(true);
            Configure(builder);
        }

        protected abstract void Configure(EntityTypeBuilder<T> builder);
    }
}