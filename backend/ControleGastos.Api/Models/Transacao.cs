using System.ComponentModel.DataAnnotations;
using ControleGastos.Api.Enums;

namespace ControleGastos.Api.Models;

public class Transacao
{
    [Key]
    public ulong Id { get; set; }
    
    [Required]
    [MaxLength(300)]
    public string Descricao { get; set; } = string.Empty;
    
    [Required]
    [Range(0, double.MaxValue)] // Podem estar registradas transações gratuitas também
    public decimal Valor { get; set; }
    
    public ETipoTransacao Tipo { get; set; }
    
    // Relacionamentos
    public ulong PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
    
    public ulong CategoriaId { get; set; }
    public Categoria Categoria { get; set; } // Considerando que cada transação possui somente uma categoria
}