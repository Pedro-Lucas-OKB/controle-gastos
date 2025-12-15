using ControleGastos.Api.Enums;

namespace ControleGastos.Api.Dtos;

public sealed record TotalCategoriaDto
{
    public ulong Id { get; init; }
    public string Descricao { get; init; } = string.Empty;
    public EFinalidadeCategoria Finalidade { get; init; }
    
    public decimal TotalReceitas { get; init; }
    public decimal TotalDespesas { get; init; }
    public decimal Saldo => TotalReceitas - TotalDespesas;
}