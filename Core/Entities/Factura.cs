namespace Core.Entities;

public class Factura : BaseEntity
{
    public int IdOrdenServicioFK { get; set; }
    public OrdenServicio OrdenServicio { get; set; }
    public DateTime FechaFactura { get; set; }
    public int IdClienteFK { get; set; }
    public Cliente Cliente { get; set; }
    public double Subtotal { get; set; }
    public double ValorTotal { get; set; }
    public double Iva { get; set; }
    public double ValorManoObra { get; set; }
    public ICollection<DetalleFactura> DetallesFactura { get; set; }
}
