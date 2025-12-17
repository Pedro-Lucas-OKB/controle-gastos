namespace ControleGastos.Api.Dtos.Relatorios;

public sealed record RelatorioTotaisPorPessoaDto
{
    public IEnumerable<TotalPessoaDto>? TotaisPorPessoa { get; init; }
    public decimal TotalReceitasGeral { get; init; }
    public decimal TotalDespesasGeral { get; init; }
    public decimal SaldoGeral => TotalReceitasGeral - TotalDespesasGeral;
}