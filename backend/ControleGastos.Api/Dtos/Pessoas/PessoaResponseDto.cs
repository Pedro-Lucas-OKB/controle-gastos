using ControleGastos.Api.Models;

namespace ControleGastos.Api.Dtos.Pessoas;

public sealed record PessoaResponseDto
{
    public ulong Id { get; init; }
    public string NomeCompleto { get; init; } = string.Empty;
    public ushort Idade { get; init; }

    /// <summary>
    /// Define uma conversão implícita entre a entidade de Pessoa e o DTO.
    /// </summary>
    /// <param name="pessoa"></param>
    /// <returns>Um objeto 'PessoaResponseDto' com os dados mapeados de 'Pessoa'</returns>
    public static implicit operator PessoaResponseDto(Pessoa pessoa)
        => new()
        {
            Id = pessoa.Id,
            NomeCompleto = pessoa.NomeCompleto,
            Idade = pessoa.Idade
        };
    
    /// <summary>
    /// Converte uma lista de Pessoas em uma lista de PessoaResponseDto.
    /// </summary>
    /// <param name="pessoas"></param>
    /// <returns>Uma lista de 'PessoaResponseDto'</returns>
    public static IEnumerable<PessoaResponseDto> ConverterLista(IEnumerable<Pessoa> pessoas)
    {
        List<PessoaResponseDto> lista = [];
        
        foreach (var pessoa in pessoas)   
        {
            lista.Add(pessoa);    
        }
        
        return lista;
    }
}