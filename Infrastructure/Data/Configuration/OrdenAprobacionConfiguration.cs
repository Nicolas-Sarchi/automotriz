using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class OrdenAprobacionConfiguration : IEntityTypeConfiguration<OrdenAprobacion>
{
    public void Configure(EntityTypeBuilder<OrdenAprobacion> builder)
    {
        builder.ToTable("orden_aprobacion");

        builder.Property(p => p.NroOrdenAprobacion)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.FechaOrdenAprobacion)
        .IsRequired()
        .HasColumnType("datetime");

        builder.HasOne(p => p.Empleado)
            .WithMany(d => d.OrdenesAprobacion)
            .HasForeignKey(e => e.IdEmpleadoFK);

        builder.HasOne(p => p.OrdenServicio)
            .WithMany(d => d.OrdenesAprobacion)
            .HasForeignKey(e => e.IdOrdenServicioFK);

        builder.HasOne(p => p.Empleado)
            .WithMany(d => d.OrdenesAprobacion)
            .HasForeignKey(e => e.IdEmpleadoFK);
    }
}
