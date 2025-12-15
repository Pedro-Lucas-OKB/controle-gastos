namespace ControleGastos.Api.Dtos;

public class RelatorioTotaisPorCategoriaDto
{
    public IEnumerable<TotalCategoriaDto> TotaisPorCategoria { get; set; }
    public decimal TotalReceitasGeral { get; set; }
    public decimal TotalDespesasGeral { get; set; }
    public decimal SaldoGeral => TotalReceitasGeral - TotalDespesasGeral;
}