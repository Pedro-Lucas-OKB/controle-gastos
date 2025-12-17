using ControleGastos.Api.Models;

namespace ControleGastos.Api.Dtos.Pessoas;

public record CriarPessoaDto
{
    public string NomeCompleto { get; init; } = string.Empty;
    public ushort Idade { get; init; }
    
    /// <summary>
    /// Define uma conversão implícita entre o DTO e a entidade de Pessoa.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>Um obtejo 'Pessoa' com os dados mapeados de 'CriarPessoaDto'</returns>
    public static implicit operator Pessoa(CriarPessoaDto dto)
        => new()
        {
            NomeCompleto = dto.NomeCompleto,
            Idade = dto.Idade
        };
}