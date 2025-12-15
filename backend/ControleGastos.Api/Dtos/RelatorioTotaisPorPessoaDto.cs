namespace ControleGastos.Api.Dtos;

public class RelatorioTotaisPorPessoaDto
{
    public IEnumerable<TotalPessoaDto> TotaisPorPessoa { get; set; }
    public decimal TotalReceitasGeral { get; set; }
    public decimal TotalDespesasGeral { get; set; }
    public decimal SaldoGeral => TotalReceitasGeral - TotalDespesasGeral;
}