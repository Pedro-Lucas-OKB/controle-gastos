using ControleGastos.Api.Enums;
using ControleGastos.Api.Models;

namespace ControleGastos.Api.Dtos.Categorias;

public sealed record CategoriaResponseDto
{
    public ulong Id { get; set; }
    public string Descricao { get; init; } = string.Empty;
    public EFinalidadeCategoria Finalidade { get; init; }
    
    /// <summary>
    /// Define uma conversão implícita entre a entidade de Categoria e o DTO.
    /// </summary>
    /// <param name="categoria"></param>
    /// <returns>Um objeto 'CategoriaResponseDto' com os dados mapeados de 'Categoria'</returns>
    public static implicit operator CategoriaResponseDto(Categoria categoria)
        => new()
        {
            Id = categoria.Id,
            Descricao = categoria.Descricao,
            Finalidade = categoria.Finalidade
        };
    
    /// <summary>
    /// Converte uma lista de Categorias em uma lista de CategoriaResponseDto.
    /// </summary>
    /// <param name="categorias"></param>
    /// <returns>Uma lista de 'CategoriaResponseDto'</returns>
    public static IEnumerable<CategoriaResponseDto> ConverterLista(IEnumerable<Categoria> categorias)
    {
        List<CategoriaResponseDto> lista = [];
        
        foreach (var categoria in categorias)   
        {
            lista.Add(categoria);    
        }
        
        return lista;
    }
}