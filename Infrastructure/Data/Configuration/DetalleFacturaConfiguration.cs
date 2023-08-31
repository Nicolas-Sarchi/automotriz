using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class DetalleFacturaConfiguration : IEntityTypeConfiguration<DetalleFactura>
    {
        public void Configure(EntityTypeBuilder<DetalleFactura> builder)
        {
            builder.ToTable("detalle_factura");

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
            builder.Property(df => df.IdFacturaFK)
                .IsRequired();

            builder.HasOne(df => df.Factura)
                .WithMany(f => f.DetallesFactura)
                .HasForeignKey(df => df.IdFacturaFK);

        }
    }
}
