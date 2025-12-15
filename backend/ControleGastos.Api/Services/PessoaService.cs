using ControleGastos.Api.Data;
using ControleGastos.Api.Models;
using ControleGastos.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.Api.Services;

public class PessoaService : IPessoaService
{
    private readonly AppDbContext _context;

    public PessoaService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Pessoa> CriarAsync(Pessoa pessoa)
    {
        await _context.Pessoas.AddAsync(pessoa);
        await _context.SaveChangesAsync();
        
        return pessoa;
    }

    public async Task<Pessoa> ExcluirAsync(ulong id)
    {
        var pessoa = await _context.Pessoas
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pessoa is null)
            throw new InvalidOperationException("Pessoa não encontrada.");
        
        _context.Pessoas.Remove(pessoa);
        await _context.SaveChangesAsync();
        
        return pessoa;
    }

    public async Task<IEnumerable<Pessoa>> ListarAsync()
    {
        return await _context.Pessoas
            .AsNoTracking()
            .Include(p => p.Transacoes)
            .ToListAsync();
    }
}