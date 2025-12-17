using ControleGastos.Api.Enums;
using ControleGastos.Api.Models;

namespace ControleGastos.Api.Dtos.Transacoes;

public sealed record TransacaoResponseDto
{
    public ulong Id { get; init; }
    public string Descricao { get; init; } = string.Empty;
    public decimal Valor { get; init; }
    public ETipoTransacao Tipo { get; init; }
    public ulong PessoaId { get; init; }
    public string NomePessoa { get; set; } = string.Empty;
    public ulong CategoriaId { get; init; }
    public string DescricaoCategoria { get; set; } = string.Empty;
    public EFinalidadeCategoria FinalidadeCategoria { get; set; }
    
    /// <summary>
    /// Define uma conversão implícita entre a entidade de Transacao e o DTO.
    /// </summary>
    /// <param name="transacao"></param>
    /// <returns>Um objeto 'TransacaoResponseDto' com os dados mapeados de 'Transacao'</returns>
    public static implicit operator TransacaoResponseDto(Transacao transacao)
        => new()
        {
            Id = transacao.Id,
            Descricao = transacao.Descricao,
            Valor = transacao.Valor,
            Tipo = transacao.Tipo,
            PessoaId = transacao.PessoaId,
            NomePessoa = transacao.Pessoa.NomeCompleto,
            CategoriaId = transacao.CategoriaId,
            DescricaoCategoria = transacao.Categoria.Descricao,
            FinalidadeCategoria = transacao.Categoria.Finalidade
        };
    
    /// <summary>
    /// Converte uma lista de Transações em uma lista de TransacaoResponseDto.
    /// </summary>
    /// <param name="transacoes"></param>
    /// <returns>Uma lista de 'TransacaoResponseDto'</returns>
    public static IEnumerable<TransacaoResponseDto> ConverterLista(IEnumerable<Transacao> transacoes)
    {
        List<TransacaoResponseDto> lista = [];
        
        foreach (var transacao in transacoes)   
        {
            lista.Add(transacao);    
        }
        
        return lista;
    }
}