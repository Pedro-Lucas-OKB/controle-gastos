using ControleGastos.Api.Dtos.Relatorios;
using ControleGastos.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class RelatoriosController : ControllerBase
{
    private readonly IRelatorioService _relatorioService;
    
    public RelatoriosController(IRelatorioService relatorioService)
    {
        _relatorioService = relatorioService;
    }
    
    /// <summary>
    /// Obtem a lista de todas as pessoas e seus respectivos totais de receitas e despesas,
    ///  juntamente com os valores totais gerais de receitas e despesas.
    /// </summary>
    /// <returns>Relatório detalhado dos gastos por pessoa.</returns>
    /// <response code="200">Retorna um 'RelatorioTotaisPorPessoaDto' com um relatório detalhado de gastos por pessoa e gastos gerais.</response>
    [HttpGet("totais-por-pessoa")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RelatorioTotaisPorPessoaDto))]
    public async Task<ActionResult<RelatorioTotaisPorPessoaDto>> ObterTotaisPorPessoaAsync()
    {
        return Ok(await _relatorioService.ObterTotaisPorPessoaAsync());
    }
    
    /// <summary>
    /// Obtem a lista de todas as categorias e seus respectivos totais de receitas e despesas,
    ///  juntamente com os valores totais gerais de receitas e despesas.
    /// </summary>
    /// <returns>Relatório detalhado dos gastos por categoria.</returns>
    /// <response code="200">Retorna um 'RelatorioTotaisPorCategoriaDto' com um relatório detalhado de gastos por categoria e gastos gerais.</response>
    [HttpGet("totais-por-categoria")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RelatorioTotaisPorCategoriaDto))]
    public async Task<ActionResult<RelatorioTotaisPorCategoriaDto>> ObterTotaisPorCategoriaAsync()
    {
        return Ok(await _relatorioService.ObterTotaisPorCategoriaAsync());
    }
}