using ControleGastos.Api.Dtos.Categorias;
using ControleGastos.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleGastos.Api.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;
    
    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }
    
    /// <summary>
    /// Cadastra uma nova categoria na base de dados.
    /// </summary>
    /// <param name="categoria"></param>
    /// <returns>Os dados da categoria cadastrada.</returns>
    /// <response code="201">Retorna um objeto 'CategoriaResponseDto' com os dados da pessoa cadastrada.</response>
    [HttpPost("cadastrar")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CategoriaResponseDto))]
    public async Task<ActionResult<CategoriaResponseDto>> CriarAsync([FromBody] CriarCategoriaDto categoria)
    {
        CategoriaResponseDto categoriaCriada = await _categoriaService.CriarAsync(categoria);
        return CreatedAtAction(
            nameof(ObterPorIdAsync),
            new {id = categoriaCriada.Id},
            categoriaCriada);
    }
    
    /// <summary>
    /// Lista todas as categorias cadastradas na base de dados.
    /// </summary>
    /// <returns>Uma lista das categorias cadastradas.</returns>
    /// <response code="200">Retorna um IEnumerable de CategoriaResponseDto.</response>
    [HttpGet("listar-categorias")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoriaResponseDto>))]
    public async Task<ActionResult<IEnumerable<CategoriaResponseDto>>> ListarCategoriasAsync()
    {
        var lista = CategoriaResponseDto.ConverterLista(await _categoriaService.ListarAsync());
        return Ok(lista);
    }
    
    /// <summary>
    /// Obtém uma categoria por seu ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Os dados de uma categoria cadastrada a partir de seu ID.</returns>
    /// <response code="200">Retorna um objeto 'CategoriaResponseDto' com os dados da categoria encontrada.</response>
    /// <response code="404">Retorna um Not Found caso a categoria não exista na base de dados.</response>
    [HttpGet("obter-categoria/{id}")]
    [ActionName("ObterPorIdAsync")] // Adicionando explicitamente o nome da action para evitar warning
    public async Task<ActionResult<CategoriaResponseDto>> ObterPorIdAsync([FromRoute] ulong id)
    {
        var categoria = await _categoriaService.ObterPorIdAsync(id);

        if (categoria is null)
            return NotFound("Categoria não encontrada.");

        CategoriaResponseDto categoriaResponseDto = categoria;
        return Ok(categoriaResponseDto);
    }
}