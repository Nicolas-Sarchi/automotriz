using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");

        builder.Property(e => e.CedulaPersona)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(e => e.NombrePersona)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.ApellidoPersona)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.EmailPersona)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.TelefonoPersona)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(e => e.FechaRegistro)
        .IsRequired()
        .HasColumnType("datetime");

    }
}
