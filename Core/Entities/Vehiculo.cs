namespace Core.Entities;
public class Vehiculo : BaseEntity
{
    public string PlacaVehiculo { get; set; }
    public string MarcaVehiculo { get; set; }
    public string ModeloVehiculo { get; set; }
    public string ColorVehiculo { get; set; }
    public string KilometrajeVehiculo { get; set; }
    public int IdClienteFk { get; set; }
    public Cliente Cliente { get; set; }
    public ICollection<OrdenServicio> OrdenesServicio { get; set; }
}
