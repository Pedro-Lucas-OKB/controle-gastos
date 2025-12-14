using ControleGastos.Api.Enums;

namespace ControleGastos.Api.Models;

public class Categoria
{
    public ulong Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public EFinalidadeCategoria Finalidade { get; set; }
    
    // Relacionamentos
    public List<Transacao> Transacoes { get; set; } = []; // Cada categoria conterá uma lista de transações associadas
}