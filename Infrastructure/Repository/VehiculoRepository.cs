using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repository;

public class VehiculoRepository : GenericRepo<Vehiculo>, IVehiculo
{
    private readonly AutomotrizContext _context;
    public VehiculoRepository(AutomotrizContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Vehiculo>> GetAllAsync()
    {
        return await _context.Vehiculos
            .Include(v => v.Cliente)
            .Include(v => v.OrdenesServicio)
            .ToListAsync();
    }

    public override async Task<Vehiculo> GetByIdAsync(int id)
    {
        return await _context.Vehiculos
            .Include(v => v.Cliente)
            .Include(v => v.OrdenesServicio)
            .FirstOrDefaultAsync(v => v.Id == id);
    }
}
