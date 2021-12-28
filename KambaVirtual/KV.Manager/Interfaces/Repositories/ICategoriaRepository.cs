using KV.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KV.Manager.Interfaces.Repositories
{
    public interface ICategoriaRepository
    {
        Task<Categoria> DeleteClienteAsync(int id);
        Task<Categoria> GetCategoriaAsync(int id);
        Task<IEnumerable<Categoria>> GetCategoriasAsync();
        Task<Categoria> InsertCategoriaAsync(Categoria novaCategoria);
        Task<Categoria> UpdateCategoriaAsync(Categoria categoria);
    }
}
