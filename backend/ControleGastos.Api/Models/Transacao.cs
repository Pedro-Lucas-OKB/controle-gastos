using ControleGastos.Api.Enums;

namespace ControleGastos.Api.Models;

public class Transacao
{
    public ulong Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public ETipoTransacao Tipo { get; set; }
    
    // Relacionamentos
    public ulong PessoaId { get; set; }
    public Pessoa Pessoa { get; set; }
    
    public ulong CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}