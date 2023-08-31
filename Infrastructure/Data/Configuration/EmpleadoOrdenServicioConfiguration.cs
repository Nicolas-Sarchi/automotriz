using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class EmpleadoOrdenServicioConfiguration : IEntityTypeConfiguration<EmpleadoOrdenServicio>
{
    public void Configure(EntityTypeBuilder<EmpleadoOrdenServicio> builder)
    {
        builder.ToTable("empleado_orden_servicio");

        builder.HasOne(e => e.Empleado)
        .WithMany(e => e.EmpleadosOrdenesServicio)
        .HasForeignKey(e => e.IdEmpleadoFk);

        builder.HasOne(e => e.OrdenServicio)
        .WithMany(e => e.EmpleadosOrdenesServicio)
        .HasForeignKey(e => e.IdOrdenServicioFk);
    }
}
