using ControleGastos.Api.Data;
using ControleGastos.Api.Dtos;
using ControleGastos.Api.Enums;
using ControleGastos.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.Api.Services;

public class RelatorioService : IRelatorioService
{
    private readonly AppDbContext _context;

    public RelatorioService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<RelatorioTotaisPorPessoaDto> ObterTotaisPorPessoaAsync()
    {
        // Obtendo a lista de pessoas e seus respectivos totais
        var totaisPorPessoa = await _context.Pessoas
            .AsNoTracking()
            .Select(p => new TotalPessoaDto
            {
                Id = p.Id,
                NomeCompleto = p.NomeCompleto,
                Idade = p.Idade,
                TotalReceitas = (decimal)p.Transacoes
                    .Where(t => t.Tipo == ETipoTransacao.Receita)
                    .Sum(t => (double)t.Valor),
                TotalDespesas = (decimal)p.Transacoes
                    .Where(t => t.Tipo == ETipoTransacao.Despesa)
                    .Sum(t => (double)t.Valor),
            })
            .ToListAsync();

        return new RelatorioTotaisPorPessoaDto()
        {
            TotaisPorPessoa = totaisPorPessoa,
            TotalReceitasGeral = totaisPorPessoa.Sum(t => t.TotalReceitas),
            TotalDespesasGeral = totaisPorPessoa.Sum(t => t.TotalDespesas)
        };
    }

    public async Task<RelatorioTotaisPorCategoriaDto> ObterTotaisPorCategoriaAsync()
    {
        var totaisPorCategoria = await _context.Categorias
            .Select(c => new TotalCategoriaDto
            {
                Id = c.Id,
                Descricao = c.Descricao,
                Finalidade = c.Finalidade,
                TotalReceitas = (decimal)c.Transacoes
                    .Where(t => t.Tipo == ETipoTransacao.Receita)
                    .Sum(t => (double)t.Valor),
                TotalDespesas = (decimal)c.Transacoes
                    .Where(t => t.Tipo == ETipoTransacao.Despesa)
                    .Sum(t => (double)t.Valor),
            })
            .ToListAsync();

        return new RelatorioTotaisPorCategoriaDto()
        {
            TotaisPorCategoria = totaisPorCategoria,
            TotalReceitasGeral = totaisPorCategoria.Sum(t => t.TotalReceitas),
            TotalDespesasGeral = totaisPorCategoria.Sum(t => t.TotalDespesas)
        };
    }
}