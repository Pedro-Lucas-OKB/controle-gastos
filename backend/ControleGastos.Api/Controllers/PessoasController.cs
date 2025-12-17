using ControleGastos.Api.Dtos.Pessoas;
using ControleGastos.Api.Models;
using ControleGastos.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class PessoasController : ControllerBase
{
    private readonly IPessoaService _pessoaService;
    
    public PessoasController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }
    
    /// <summary>
    /// Cadastra uma nova pessoa na base de dados.
    /// </summary>
    /// <param name="pessoa"></param>
    /// <returns>Os dados da pessoa cadastrada.</returns>
    /// <response code="201">Retorna um objeto 'PessoaResponseDto' com os dados da pessoa cadastrada.</response>
    [HttpPost("cadastrar")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PessoaResponseDto))]
    public async Task<ActionResult<PessoaResponseDto>> CriarAsync([FromBody] CriarPessoaDto pessoa)
    {
        PessoaResponseDto pessoaCriada = await _pessoaService.CriarAsync(pessoa);
        return CreatedAtAction(
            nameof(ObterPorIdAsync),
            new {id = pessoaCriada.Id},
            pessoaCriada);
    }
    
    /// <summary>
    /// Exclui uma pessoa da base de dados.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Os dados da pessoa excluída.</returns>
    /// <response code="200">Retorna um objeto 'PessoaResponseDto' com os dados da pessoa excluída.</response>
    /// <response code="400">Retorna um Bad Request caso a pessoa não exista na base de dados..</response>
    [HttpDelete("excluir/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PessoaResponseDto>> ExcluirAsync([FromRoute] ulong id)
    {
        try
        {
            PessoaResponseDto pessoaExcluida = await _pessoaService.ExcluirAsync(id);
            return Ok(pessoaExcluida);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Lista todas as pessoas cadastradas na base de dados.
    /// </summary>
    /// <returns>Uma lista das pessoas cadastradas.</returns>
    /// <response code="200">Retorna um IEnumerable de PessoaResponseDto.</response>
    [HttpGet("listar-pessoas")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PessoaResponseDto>))]
    public async Task<ActionResult<IEnumerable<PessoaResponseDto>>> ListarPessoasAsync()
    {
        var lista = PessoaResponseDto.ConverterLista(await _pessoaService.ListarAsync());
        return Ok(lista);
    }
    
    /// <summary>
    /// Obtém uma pessoa por seu ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Os dados de uma pessoa cadastrada a partir de seu ID.</returns>
    /// <response code="200">Retorna um objeto 'PessoaResponseDto' com os dados da pessoa encontrada.</response>
    /// <response code="404">Retorna um Not Found caso a pessoa não exista na base de dados.</response>
    [HttpGet("obter-pessoa/{id}")]
    [ActionName("ObterPorIdAsync")] // Adicionando explicitamente o nome da action para evitar warning
    public async Task<ActionResult<PessoaResponseDto>> ObterPorIdAsync([FromRoute] ulong id)
    {
        var pessoa = await _pessoaService.ObterPorIdAsync(id);

        if (pessoa is null)
            return NotFound("Pessoa não encontrada.");

        PessoaResponseDto pessoaResponseDto = pessoa;
        return Ok(pessoaResponseDto);
    }
}