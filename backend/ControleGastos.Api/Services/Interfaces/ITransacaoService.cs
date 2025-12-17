using ControleGastos.Api.Models;

namespace ControleGastos.Api.Services.Interfaces;

public interface ITransacaoService
{
    Task<Transacao> CriarAsync(Transacao transacao);
    Task<IEnumerable<Transacao>> ListarAsync();
    Task<IEnumerable<Transacao>> ListarCompletoAsync();
    Task<Transacao?> ObterPorIdAsync(ulong id);
    Task<Transacao?> ObterPorIdCompletoAsync(ulong id);
}