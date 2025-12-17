using ControleGastos.Api.Dtos.Transacoes;
using ControleGastos.Api.Services;
using ControleGastos.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class TransacoesController : ControllerBase
{
    private readonly ITransacaoService _transacaoService;

    public TransacoesController(ITransacaoService transacaoService)
    {
        _transacaoService = transacaoService;
    }
    
    /// <summary>
    /// Cadastra uma nova transação na base de dados.
    /// </summary>
    /// <param name="transacao"></param>
    /// <returns>Os dados da transação cadastrada.</returns>
    /// <response code="201">Retorna um objeto 'TransacaoResponseDto' com os dados da transação cadastrada.</response>
    /// <response code="400">Retorna um Bad Request caso ocorram problemas no cadastro.</response>
    [HttpPost("cadastrar")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TransacaoResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TransacaoResponseDto>> CriarAsync([FromBody] CriarTransacaoDto transacao)
    {
        try
        {
            TransacaoResponseDto transacaoCriada = await _transacaoService.CriarAsync(transacao);
            return CreatedAtAction(
                nameof(ObterPorIdAsync),
                new {id = transacaoCriada.Id},
                transacaoCriada);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Lista todas as transações cadastradas na base de dados.
    /// </summary>
    /// <returns>Uma lista das transações cadastradas.</returns>
    /// <response code="200">Retorna um IEnumerable de TransacaoResponseDto.</response>
    [HttpGet("listar-transacoes")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TransacaoResponseDto>))]
    public async Task<ActionResult<IEnumerable<TransacaoResponseDto>>> ListarTransacoesAsync()
    {
        var lista = TransacaoResponseDto.ConverterLista(await _transacaoService.ListarCompletoAsync());
        return Ok(lista);
    }
    
    /// <summary>
    /// Obtém uma transação por seu ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Os dados de uma transação cadastrada a partir de seu ID.</returns>
    /// <response code="200">Retorna um objeto 'TransacaoResponseDto' com os dados da transação encontrada.</response>
    /// <response code="404">Retorna um Not Found caso a transação não exista na base de dados.</response>
    [HttpGet("obter-transacao/{id}")]
    [ActionName("ObterPorIdAsync")] // Adicionando explicitamente o nome da action para evitar warning
    public async Task<ActionResult<TransacaoResponseDto>> ObterPorIdAsync([FromRoute] ulong id)
    {
        var transacao = await _transacaoService.ObterPorIdCompletoAsync(id);

        if (transacao is null)
            return NotFound("Transação não encontrada.");

        TransacaoResponseDto transacaoResponseDto = transacao;
        return Ok(transacaoResponseDto);
    }
}