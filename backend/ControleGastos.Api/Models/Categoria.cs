using System.ComponentModel.DataAnnotations;
using ControleGastos.Api.Enums;

namespace ControleGastos.Api.Models;

public class Categoria
{
    [Key]
    public ulong Id { get; set; }
    
    [Required]
    [MaxLength(300)]
    public string Descricao { get; set; } = string.Empty;
    
    public EFinalidadeCategoria Finalidade { get; set; }
    
    // Relacionamentos
    public List<Transacao> Transacoes { get; set; } = []; // Cada categoria conterá uma lista de transações associadas
}