using System.ComponentModel.DataAnnotations;

namespace ControleGastos.Api.Models;
/*
 * Como é só um teste para a vaga, decidi por utilizar entidades anêmicas mesmo.
 * Entretanto, informo que tenho conhecimentos em DDD e já fiz projetos com Rich Domain Model.
*/

public class Pessoa
{
    [Key]
    public ulong Id { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string NomeCompleto { get; set; } = string.Empty;
    
    [Required]
    public ushort Idade { get; set; }
    
    // Relacionamentos
    public List<Transacao> Transacoes { get; set; } = []; // Cada pessoa conterá uma lista de transações
}