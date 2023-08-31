using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class VehiculoConfiguration : IEntityTypeConfiguration<Vehiculo>
{
    public void Configure(EntityTypeBuilder<Vehiculo> builder)
    {
        builder.ToTable("vehiculo");

        builder.Property(v => v.PlacaVehiculo)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(v => v.MarcaVehiculo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(v => v.ModeloVehiculo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(v => v.ColorVehiculo)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(v => v.KilometrajeVehiculo)
            .HasMaxLength(10);

        builder.Property(v => v.IdClienteFk)
            .IsRequired();

        builder.HasOne(v => v.Cliente)
            .WithMany(c => c.Vehiculos)
            .HasForeignKey(v => v.IdClienteFk);


    }
}

