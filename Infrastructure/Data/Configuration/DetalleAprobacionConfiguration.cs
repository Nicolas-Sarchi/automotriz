using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class DetalleAprobacionConfiguration : IEntityTypeConfiguration<DetalleAprobacion>
{
    public void Configure(EntityTypeBuilder<DetalleAprobacion> builder)
    {
        builder.ToTable("detalle_aprobacion");
        builder.Property(da => da.Repuesto)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(da => da.Cantidad)
        .IsRequired()
        .HasColumnType("int");

        builder.Property(da => da.ValorUnitario)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(da => da.ValorTotal)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder.Property(da => da.IdOrdenAprobacionFK)
            .IsRequired();

        builder.Property(da => da.Estado)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(da => da.OrdenAprobacion)
            .WithMany(oa => oa.DetallesAprobacion)
            .HasForeignKey(da => da.IdOrdenAprobacionFK);

    }
}

