namespace Core.Entities;

public class Cliente : Persona
{
    public DateTime FechaRegistro { get; set; }
    public ICollection<Vehiculo> Vehiculos { get; set; }
    public ICollection<OrdenServicio> OrdenesServicios { get; set; }
    public ICollection<Factura> Facturas { get; set; }
}
