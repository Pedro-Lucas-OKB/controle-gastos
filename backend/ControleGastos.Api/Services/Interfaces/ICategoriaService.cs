using ControleGastos.Api.Models;

namespace ControleGastos.Api.Services.Interfaces;

public interface ICategoriaService
{
    Task<Categoria> CriarAsync(Categoria categoria);
    Task<IEnumerable<Categoria>> ListarAsync();
}