namespace Core.Entities;

public class Detalle : BaseEntity
{
    public string Repuesto { get; set; }
    public double ValorUnitario { get; set; }
    public int Cantidad { get; set; }
    public double ValorTotal { get; private set; }
}
