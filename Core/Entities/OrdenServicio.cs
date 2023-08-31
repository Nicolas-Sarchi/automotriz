namespace Core.Entities;

public class OrdenServicio : BaseEntity
{
    public int NroOrden { get; set; }
    public DateTime FechaOrden { get; set; }
    public int IdClienteFK { get; set; }
    public Cliente Cliente { get; set; }
    public string DiagnosticoCliente { get; set; }
    public int IdVehiculoFK { get; set; }
    public Vehiculo Vehiculo { get; set; }
    public ICollection<OrdenAprobacion> OrdenesAprobacion { get; set; }
    public ICollection<DiagnosticoEmpleado> DiagnosticosEmpleados { get; set; }
    public int IdFacturaFK { get; set; }
    public Factura Factura { get; set; }
    public ICollection<EmpleadoOrdenServicio> EmpleadosOrdenesServicio { get; set; }
    public ICollection<Empleado> Empleados { get; set; }

}
