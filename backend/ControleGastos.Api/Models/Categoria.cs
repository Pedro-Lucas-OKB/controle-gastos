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
    
    [Required]
    [Range(1, 3, ErrorMessage = "A finalidade da categoria deve ser entre 1 e 3.")]
    public EFinalidadeCategoria Finalidade { get; set; }
    
    // Relacionamentos
    public List<Transacao> Transacoes { get; set; } = []; // Cada categoria conterá uma lista de transações associadas
}