using System.ComponentModel.DataAnnotations;
using ControleGastos.Api.Enums;

namespace ControleGastos.Api.Models;

public class Transacao
{
    [Key]
    public ulong Id { get; set; }
    
    [Required(ErrorMessage = "É obrigatório informar a descrição da transação.")]
    [MaxLength(300, ErrorMessage = "Limite de caracteres excedido.")]
    public string Descricao { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "É obrigatório informar o valor da transação.")]
    [Range(0, double.MaxValue, ErrorMessage = "Valor inválido.")] // Podem estar registradas transações gratuitas também
    public decimal Valor { get; set; }
    
    [Required(ErrorMessage = "É obrigatório informar o tipo da transação.")]
    [Range(1, 2, ErrorMessage = "O tipo da transação deve ser 1 ou 2.")]
    public ETipoTransacao Tipo { get; set; }
    
    // Relacionamentos
    public ulong PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
    
    public ulong CategoriaId { get; set; }
    public Categoria Categoria { get; set; } // Considerando que cada transação possui somente uma categoria
}