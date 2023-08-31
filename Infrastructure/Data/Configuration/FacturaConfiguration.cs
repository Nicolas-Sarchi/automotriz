using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("facturas");

            builder.Property(f => f.IdOrdenServicioFK)
                .IsRequired();

            builder.Property(f => f.FechaFactura)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(f => f.IdClienteFK)
                .IsRequired();

            builder.Property(f => f.Subtotal)
                .IsRequired();

            builder.Property(f => f.ValorTotal)
                .IsRequired();

            builder.Property(f => f.Iva)
                .IsRequired();

            builder.Property(f => f.ValorManoObra)
                .IsRequired();

            builder.HasOne(f => f.OrdenServicio)
                .WithOne(os => os.Factura)
                .HasForeignKey<Factura>(f => f.IdOrdenServicioFK);

            builder.HasOne(f => f.Cliente)
                .WithMany(c => c.Facturas)
                .HasForeignKey(f => f.IdClienteFK);

            builder.HasMany(f => f.DetallesFactura)
                .WithOne(df => df.Factura)
                .HasForeignKey(df => df.IdFacturaFK);

        }
    }
}
