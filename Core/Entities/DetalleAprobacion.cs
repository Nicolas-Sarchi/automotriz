namespace Core.Entities;

public class DetalleAprobacion : Detalle
{
    public int IdOrdenAprobacionFK { get; set; }

    public OrdenAprobacion OrdenAprobacion { get; set; }
    public string Estado { get; set; }
}
