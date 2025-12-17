using ControleGastos.Api.Dtos.Relatorios;

namespace ControleGastos.Api.Services.Interfaces;

public interface IRelatorioService
{
    Task<RelatorioTotaisPorPessoaDto> ObterTotaisPorPessoaAsync();
    Task<RelatorioTotaisPorCategoriaDto> ObterTotaisPorCategoriaAsync();
}