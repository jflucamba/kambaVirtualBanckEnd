using KV.Core.Domain;
using KV.Core.Shared.ModelView.Comentario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KV.Manager.Interfaces.Repositories
{
    public interface IComentarioRepository
    {
        Task<Comentario> DeleteComentarioAsync(int id);
        Task<Comentario> GetComentarioAsync(int id);
        Task<IEnumerable<Comentario>> GetComentariosAsync();
        Task<Comentario> InsertComentarioAsync(Comentario novoComentario);
        Task<Comentario> UpdateComentarioAsync(AlterarComentario comentario);
    }
}
