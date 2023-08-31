using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class DiagnosticoEmpleadoConfiguration : IEntityTypeConfiguration<DiagnosticoEmpleado>
{
    public void Configure(EntityTypeBuilder<DiagnosticoEmpleado> builder)
    {
        builder.ToTable("diagnostico_empleado");

        builder.Property(de => de.Descripcion)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(de => de.IdEmpleadoFK)
            .IsRequired();

        builder.Property(de => de.IdOrdenServicioFK)
            .IsRequired();

        builder.HasOne(de => de.Empleado)
            .WithMany(e => e.DiagnosticosEmpleado)
            .HasForeignKey(de => de.IdEmpleadoFK);

        builder.HasOne(de => de.OrdenServicio)
            .WithMany(os => os.DiagnosticosEmpleados)
            .HasForeignKey(de => de.IdOrdenServicioFK);

    }
}

