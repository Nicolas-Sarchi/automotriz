
namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
{

    ICliente Clientes { get; }
    IEmpleado Empleados { get; }
    IVehiculo Vehiculos { get; }

    Task<int> SaveAsync();

}
