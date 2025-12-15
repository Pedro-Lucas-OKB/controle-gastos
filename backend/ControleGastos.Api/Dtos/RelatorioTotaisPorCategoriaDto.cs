namespace ControleGastos.Api.Dtos;

public sealed record RelatorioTotaisPorCategoriaDto
{
    public IEnumerable<TotalCategoriaDto>? TotaisPorCategoria { get; init; }
    public decimal TotalReceitasGeral { get; init; }
    public decimal TotalDespesasGeral { get; init; }
    public decimal SaldoGeral => TotalReceitasGeral - TotalDespesasGeral;
}