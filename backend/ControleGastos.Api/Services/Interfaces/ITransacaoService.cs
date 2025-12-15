using ControleGastos.Api.Models;

namespace ControleGastos.Api.Services.Interfaces;

public interface ITransacaoService
{
    Task<Transacao> CriarAsync(Transacao transacao);
    Task<IEnumerable<Transacao>> ListarAsync();
}