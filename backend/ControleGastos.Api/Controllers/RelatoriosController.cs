using ControleGastos.Api.Dtos;
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
    /// <returns></returns>
    [HttpGet("totais-por-pessoa")]
    public async Task<ActionResult<RelatorioTotaisPorPessoaDto>> ObterTotaisPorPessoaAsync()
    {
        return Ok(await _relatorioService.ObterTotaisPorPessoaAsync());
    }
    
    /// <summary>
    /// Obtem a lista de todas as categorias e seus respectivos totais de receitas e despesas,
    ///  juntamente com os valores totais gerais de receitas e despesas.
    /// </summary>
    /// <returns></returns>
    [HttpGet("totais-por-categoria")]
    public async Task<ActionResult<RelatorioTotaisPorCategoriaDto>> ObterTotaisPorCategoriaAsync()
    {
        return Ok(await _relatorioService.ObterTotaisPorCategoriaAsync());
    }
}