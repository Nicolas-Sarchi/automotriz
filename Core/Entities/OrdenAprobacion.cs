namespace Core.Entities;

public class OrdenAprobacion : BaseEntity
{
    public string NroOrdenAprobacion { get; set; }
    public DateTime FechaOrdenAprobacion { get; set; }
    public int IdEmpleadoFK { get; set; }
    public Empleado Empleado { get; set; }
    public int IdOrdenServicioFK { get; set; }
    public OrdenServicio OrdenServicio { get; set; }
    public ICollection<DetalleAprobacion> DetallesAprobacion { get; set; }
}
