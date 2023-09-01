namespace API.Dtos;

public class ClienteDto
{
    public int Id { get; set; }
    public string NombrePersona { get; set; }
    public DateTime FechaRegistro { get; set; }
    public List<VehiculoDto> Vehiculos { get; set; }
}
