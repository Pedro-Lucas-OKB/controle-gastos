using ControleGastos.Api.Models;

namespace ControleGastos.Api.Services.Interfaces;

public interface IPessoaService
{
    Task<Pessoa> CriarAsync(Pessoa pessoa);
    Task<Pessoa> ExcluirAsync(ulong id);
    Task<IEnumerable<Pessoa>> ListarAsync();
    Task<Pessoa?> ObterPorIdAsync(ulong id);
}