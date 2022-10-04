using KV.Core.Domain;
using KV.Core.Shared.ModelView.Comentario;
using KV.Data.Context;
using KV.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KV.Data.Repository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly KvContext context;

        public ComentarioRepository(KvContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Comentario>> GetComentariosAsync()
        {
            return await context.Comentarios
                //.Include(x => x.Endereco)
                //.Include(x => x.Telefones)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Comentario> GetComentarioAsync(int id)
        {
            return await context.Comentarios.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Comentario> InsertComentarioAsync(Comentario novoComentario)
        {
            await context.Comentarios.AddAsync(novoComentario);
            await context.SaveChangesAsync();
            return novoComentario;
        }

        public async Task<Comentario> UpdateComentarioAsync(AlterarComentario comentario)
        {
            var comentarioConsultada = await context.Comentarios
                                                 .FindAsync(comentario.Id);

            context.Entry(comentarioConsultada).CurrentValues.SetValues(comentario);

            await context.SaveChangesAsync();
            return comentarioConsultada;
        }

        //Delete
        public async Task<Comentario> DeleteComentarioAsync(int id)
        {
            var comentarioConsultado = await context.Comentarios.FindAsync(id);
            if (comentarioConsultado == null)
            {
                return null;
            }
            var autorRemovido = context.Comentarios.Remove(comentarioConsultado);
            await context.SaveChangesAsync();
            return autorRemovido.Entity;
        }
    }
}
