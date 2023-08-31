using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repository;

public class EmpleadoRepository : GenericRepo<Empleado>, IEmpleado
{
    private readonly AutomotrizContext _context;
    public EmpleadoRepository(AutomotrizContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _context.Empleados
            .Include(e => e.Especialidad)
            .Include(e => e.EmpleadosOrdenesServicio)
                .ThenInclude(eos => eos.OrdenServicio)
            .Include(e => e.OrdenesServicio)
            .Include(e => e.OrdenesAprobacion)
            .Include(e => e.DiagnosticosEmpleado)
            .ToListAsync();
    }

    public override async Task<Empleado> GetByIdAsync(int id)
    {
        return await _context.Empleados
            .Include(e => e.Especialidad)
            .Include(e => e.EmpleadosOrdenesServicio)
                .ThenInclude(eos => eos.OrdenServicio)
            .Include(e => e.OrdenesServicio)
            .Include(e => e.OrdenesAprobacion)
            .Include(e => e.DiagnosticosEmpleado)
            .FirstOrDefaultAsync(e => e.Id == id);
    }
}
