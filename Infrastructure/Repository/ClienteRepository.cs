
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Repository;

public class ClienteRepository : GenericRepo<Cliente>, ICliente
{
    private readonly AutomotrizContext _context;
    public ClienteRepository(AutomotrizContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .Include(p => p.Vehiculos)
            .ToListAsync();
    }

    public override async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes
        .Include(p => p.Vehiculos)
        .FirstOrDefaultAsync(p => p.Id == id);
    }


}
