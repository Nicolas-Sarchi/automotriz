namespace Core.Entities;

public class DiagnosticoEmpleado : BaseEntity
{
    public string Descripcion { get; set; }
    public int IdEmpleadoFK { get; set; }
    public Empleado Empleado { get; set; }
    public int IdOrdenServicioFK { get; set; }
    public OrdenServicio OrdenServicio { get; set; }
}
