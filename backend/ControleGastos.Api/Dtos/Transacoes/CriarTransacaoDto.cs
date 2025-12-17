using System.ComponentModel.DataAnnotations;
using ControleGastos.Api.Enums;
using ControleGastos.Api.Models;

namespace ControleGastos.Api.Dtos.Transacoes;

public sealed record CriarTransacaoDto
{
    [Required(ErrorMessage = "É obrigatório informar a descrição da transação.")]
    [MaxLength(300, ErrorMessage = "Limite de caracteres excedido.")]
    public string Descricao { get; init; } = string.Empty;
    
    [Required(ErrorMessage = "É obrigatório informar o valor da transação.")]
    [Range(0, double.MaxValue, ErrorMessage = "Valor inválido.")] // Podem estar registradas transações gratuitas também
    public decimal Valor { get; init; }
    
    [Required(ErrorMessage = "É obrigatório informar o tipo da transação.")]
    [Range(1, 2, ErrorMessage = "O tipo da transação deve ser 1 ou 2.")]
    public ETipoTransacao Tipo { get; init; }
    
    [Required(ErrorMessage = "É obrigatório informar o ID da pessoa relacionada.")]
    public ulong PessoaId { get; init; }
    
    [Required(ErrorMessage = "É obrigatório informar o ID da categoria relacionada.")]
    public ulong CategoriaId { get; init; }
    
    /// <summary>
    /// Define uma conversão implícita entre o DTO e a entidade de Transacao.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>Um objeto 'Transacao' com os dados mapeados de 'CriarTransacaoDto'</returns>
    public static implicit operator Transacao(CriarTransacaoDto dto)
        => new()
        {
            Descricao = dto.Descricao,
            Valor = dto.Valor,
            Tipo = dto.Tipo,
            PessoaId = dto.PessoaId,
            CategoriaId = dto.CategoriaId
        };
}