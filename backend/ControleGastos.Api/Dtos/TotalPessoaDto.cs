namespace ControleGastos.Api.Dtos;

public sealed record TotalPessoaDto
{
    public ulong Id { get; init; }
    public string NomeCompleto { get; init; } = string.Empty;
    public ushort Idade { get; init; }

    public decimal TotalReceitas { get; init; }
    public decimal TotalDespesas { get; init; }
    public decimal Saldo => TotalReceitas - TotalDespesas;
}