using ControleGastos.Api.Data;
using ControleGastos.Api.Models;
using ControleGastos.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.Api.Services;

public class CategoriaService : ICategoriaService
{
    private readonly AppDbContext _context;

    public CategoriaService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Categoria> CriarAsync(Categoria categoria)
    {
        await _context.Categorias.AddAsync(categoria);
        await _context.SaveChangesAsync();
        
        return categoria;
    }

    public async Task<IEnumerable<Categoria>> ListarAsync()
    {
        return await _context.Categorias
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Categoria?> ObterPorIdAsync(ulong id)
    {
        return await _context.Categorias
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}