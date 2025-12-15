using ControleGastos.Api.Data;
using ControleGastos.Api.Enums;
using ControleGastos.Api.Models;
using ControleGastos.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.Api.Services;

public class TransacaoService : ITransacaoService
{
    private readonly AppDbContext _context;

    public TransacaoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Transacao> CriarAsync(Transacao transacao)
    {
        // Verificando se categoria e pessoa existem
        var pessoa = await _context.Pessoas
            .FirstOrDefaultAsync(p => p.Id == transacao.PessoaId);

        if (pessoa is null)
            throw new InvalidOperationException("Pessoa não encontrada.");

        var categoria = await _context.Categorias
            .FirstOrDefaultAsync(c => c.Id == transacao.CategoriaId);

        if (categoria is null)
            throw new InvalidOperationException("Categoria não existe.");

        // Verificando idade da pessoa
        if (pessoa.Idade < 18 && categoria.Finalidade != EFinalidadeCategoria.Despesa)
            throw new InvalidOperationException("Pessoas menores de idade só podem realizar despesas.");

        // Verificando compatibilidade do tipo de transação com a finalidade da categoria
        if (categoria.Finalidade != EFinalidadeCategoria.Ambas)
        {
            if ((transacao.Tipo == ETipoTransacao.Receita && categoria.Finalidade != EFinalidadeCategoria.Receita) ||
                (transacao.Tipo == ETipoTransacao.Despesa && categoria.Finalidade != EFinalidadeCategoria.Despesa))
            {
                throw new InvalidOperationException("O tipo da transação e a finalidade da categoria não correspondem.");
            }
        }
        
        await _context.Transacoes.AddAsync(transacao);
        await _context.SaveChangesAsync();
        
        return transacao;
    }

    public async Task<IEnumerable<Transacao>> ListarAsync()
    {
        return await _context.Transacoes
            .AsNoTracking() // Boa prática não 'trackear' entidades em ações de somente consulta
            .ToListAsync();
    }
}