using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaPrayaga.Domain;

namespace SistemaPrayaga.Infraestructure
{
    public class FacultadConfiguration : EntityMapBase<Facultad>
    {
        protected override void Configure(EntityTypeBuilder<Facultad> builder)
        {
            builder.ToTable("Facultad");
            builder.Property(b => b.nombre_facultad).IsRequired().HasMaxLength(150);
            builder.Property(b => b.codigo_facultad).IsRequired().HasMaxLength(10);
        }
    }
}