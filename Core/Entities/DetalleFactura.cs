namespace Core.Entities;

public class DetalleFactura : Detalle
{
    public int IdFacturaFK { get; set; }
    public Factura Factura { get; set; }
}
