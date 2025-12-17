using ControleGastos.Api.Enums;
using ControleGastos.Api.Models;

namespace ControleGastos.Api.Dtos.Categorias;

public sealed record CriarCategoriaDto
{
    public string Descricao { get; init; } = string.Empty;
    public EFinalidadeCategoria Finalidade { get; init; }
    
    /// <summary>
    /// Define uma conversão implícita entre o DTO e a entidade de Categoria.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>Um objeto 'Categoria' com os dados mapeados de 'CriarCategoriaDto'</returns>
    public static implicit operator Categoria(CriarCategoriaDto dto)
        => new()
        {
            Descricao = dto.Descricao,
            Finalidade = dto.Finalidade
        };
}