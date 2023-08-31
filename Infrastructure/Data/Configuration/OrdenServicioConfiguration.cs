using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configuration;

public class OrdenServicioConfiguration : IEntityTypeConfiguration<OrdenServicio>
{
    public void Configure(EntityTypeBuilder<OrdenServicio> builder)
    {
        builder.ToTable("orden_servicio");

        builder.Property(e => e.NroOrden)
            .IsRequired()
            .HasColumnType("int");

        builder.Property(e => e.FechaOrden)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(e => e.DiagnosticoCliente)
        .IsRequired()
        .HasMaxLength(200);

        builder.Property(e => e.IdClienteFK)
            .IsRequired();

        builder.Property(e => e.IdVehiculoFK)
            .IsRequired();

        builder.HasOne(d => d.Cliente)
            .WithMany(p => p.OrdenesServicios)
            .HasForeignKey(d => d.IdClienteFK);

        builder.HasOne(d => d.Vehiculo)
            .WithMany(p => p.OrdenesServicio)
            .HasForeignKey(d => d.IdVehiculoFK);

        builder.HasOne(os => os.Factura)
               .WithOne(f => f.OrdenServicio)
               .HasForeignKey<Factura>(f => f.IdOrdenServicioFK);

    }
}
