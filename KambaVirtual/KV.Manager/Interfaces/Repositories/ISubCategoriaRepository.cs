using KV.Core.Domain;
using KV.Core.Shared.ModelView.SubCategoria;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KV.Manager.Interfaces.Repositories
{
    public interface ISubCategoriaRepository
    {
        Task<SubCategoria> DeleteSubCategoriaAsync(int id);

        Task<SubCategoria> GetSubCategoriaAsync(int id);

        Task<IEnumerable<SubCategoria>> GetSubCategoriasAsync();

        Task<SubCategoria> InsertSubCategoriaAsync(SubCategoria nova);

        Task<SubCategoria> UpdateSubCategoriaAsync(AlterarSubCategoria alterar);
    }
}