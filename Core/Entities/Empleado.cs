namespace Core.Entities;

public class Empleado : Persona
{
    public int IdEspecialidadFk { get; set; }
    public Especialidad Especialidad { get; set; }
    public ICollection<EmpleadoOrdenServicio> EmpleadosOrdenesServicio { get; set; }
    public ICollection<OrdenServicio> OrdenesServicio { get; set; }
    public ICollection<OrdenAprobacion> OrdenesAprobacion { get; set; }

    public ICollection<DiagnosticoEmpleado> DiagnosticosEmpleado { get; set; }

}
