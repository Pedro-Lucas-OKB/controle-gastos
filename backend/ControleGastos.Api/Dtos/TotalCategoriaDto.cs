using ControleGastos.Api.Enums;

namespace ControleGastos.Api.Dtos;

public class TotalCategoriaDto
{
    public ulong Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public EFinalidadeCategoria Finalidade { get; set; }
    
    public decimal TotalReceitas { get; set; }
    public decimal TotalDespesas { get; set; }
    public decimal Saldo => TotalReceitas - TotalDespesas;
}