using KV.Core.Domain;
using KV.Core.Shared.ModelView.SubCategoria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KV.Manager.Interfaces.Managers
{
    public interface ISubCategoriaManager
    {
        Task DeleteSubCategoriaAsync(int id);

        Task<SubCategoria> GetSubCategoriaAsync(int id);

        Task<IEnumerable<SubCategoria>> GetSubCategoriasAsync();

        Task<SubCategoria> InsertSubCategoriaAsync(NovaSubCategoria novaCategoria);

        Task<SubCategoria> UpdateSubCategoriaAsync(AlterarSubCategoria categoria);
    }
}
