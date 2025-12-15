namespace ControleGastos.Api.Dtos;

public class TotalPessoaDto
{
    public ulong Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public ushort Idade { get; set; }

    public decimal TotalReceitas { get; set; }
    public decimal TotalDespesas { get; set; }
    public decimal Saldo => TotalReceitas - TotalDespesas;
}