using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPrayaga.Domain;

namespace SistemaPrayaga.Infraestructure
{
    public class CarreraConfiguration : EntityMapBase<Carrera>
    {
        protected override void Configure(EntityTypeBuilder<Carrera> builder)
        {
            builder.ToTable("Carrera");
            builder.Property(b => b.id_facultad).IsRequired();
            builder.Property(b => b.nombre_carrera).IsRequired().HasMaxLength(150);
            builder.Property(b => b.codigo_carrera).IsRequired().HasMaxLength(10);

            builder.HasOne(b => b.Facultad)
              .WithMany(c => c.Carreras)
              .HasForeignKey(b => b.id_facultad);
        }
    }
}