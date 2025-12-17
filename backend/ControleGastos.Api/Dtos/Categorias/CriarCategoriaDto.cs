using System.ComponentModel.DataAnnotations;
using ControleGastos.Api.Enums;
using ControleGastos.Api.Models;

namespace ControleGastos.Api.Dtos.Categorias;

public sealed record CriarCategoriaDto
{
    [Required(ErrorMessage = "É obrigatório informar uma descrição para a categoria.")]
    [MaxLength(300, ErrorMessage = "Limite de caracteres excedido.")]
    public string Descricao { get; init; } = string.Empty;
    
    [Required(ErrorMessage = "É obrigatório informar a finalidade da categoria.")]
    [Range(1, 3, ErrorMessage = "A finalidade da categoria deve ser entre 1 e 3.")]
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