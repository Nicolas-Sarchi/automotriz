namespace Core.Entities;

public class EmpleadoOrdenServicio
{
    public int IdEmpleadoFk { get; set; }
    public Empleado Empleado { get; set; }
    public int IdOrdenServicioFk { get; set; }
    public OrdenServicio OrdenServicio { get; set; }

}
