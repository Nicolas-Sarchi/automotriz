namespace Core.Entities;

public class Especialidad : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Empleado> Empleados { get; set; }
}
