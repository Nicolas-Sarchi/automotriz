using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AutomotrizContext : DbContext
{
    public AutomotrizContext(DbContextOptions<AutomotrizContext> options) : base(options)
    {
    }

   public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    public DbSet<OrdenServicio> OrdenesServicio { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<OrdenAprobacion> OrdenesAprobacion { get; set; }
    public DbSet<DiagnosticoEmpleado> DiagnosticosEmpleados { get; set; }
    public DbSet<Factura> Facturas { get; set; }
    public DbSet<DetalleFactura> DetallesFactura { get; set; }
    public DbSet<DetalleAprobacion> DetallesAprobacion { get; set; }
    public DbSet<EmpleadoOrdenServicio> EmpleadosOrdenesServicio { get; set; }
    public DbSet<Especialidad> Especialidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmpleadoOrdenServicio>().HasKey(eos => new { eos.IdEmpleadoFk, eos.IdOrdenServicioFk });
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
