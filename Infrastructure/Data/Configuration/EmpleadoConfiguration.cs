using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EmpleadoConfiguration : IEntityTypeConfiguration<Empleado>
{
    public void Configure(EntityTypeBuilder<Empleado> builder)
    {
        builder.ToTable("empleado");

        builder.Property(e => e.NombrePersona)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.ApellidoPersona)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.CedulaPersona)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(e => e.TelefonoPersona)
            .HasMaxLength(20);

        builder.Property(e => e.EmailPersona)
            .HasMaxLength(100);

        builder.Property(e => e.IdEspecialidadFk)
            .IsRequired();

        builder.HasOne(e => e.Especialidad)
            .WithMany(es => es.Empleados)
            .HasForeignKey(e => e.IdEspecialidadFk);



    }

}
