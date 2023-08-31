
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;



namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AutomotrizContext context;
    private ClienteRepository _Clientes;
    private EmpleadoRepository _Empleados;

    private VehiculoRepository _Vehiculos;


    public UnitOfWork(AutomotrizContext _context)
    {
        context = _context;
    }

    public ICliente Clientes
    {
        get
        {
            if (_Clientes == null)
            {
                _Clientes = new ClienteRepository(context);
            }
            return _Clientes;
        }

    }

    public IEmpleado Empleados
    {
        get
        {
            if (_Empleados == null)
            {
                _Empleados = new EmpleadoRepository(context);
            }
            return _Empleados;
        }

    }

      public IVehiculo Vehiculos
    {
        get
        {
            if (_Vehiculos == null)
            {
                _Vehiculos = new VehiculoRepository(context);
            }
            return _Vehiculos;
        }

    }


    public void Dispose()
    {
        context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}
