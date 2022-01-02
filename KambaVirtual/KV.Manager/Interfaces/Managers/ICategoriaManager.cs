using KV.Core.Domain;
using KV.Core.Shared.ModelView.Categoria;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KV.Manager.Interfaces.Managers
{
    public interface ICategoriaManager
    {
        Task DeleteCategoriaAsync(int id);

        Task<Categoria> GetCategoriaAsync(int id);

        Task<IEnumerable<Categoria>> GetCategoriasAsync();

        Task<Categoria> InsertCategoriaAsync(NovaCategoria novaCategoria);

        Task<Categoria> UpdateCategoriaAsync(AlterarCategoria categoria);

    }
}