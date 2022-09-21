using KV.Core.Domain;
using KV.Core.Shared.ModelView.Autor;
using KV.Data.Context;
using KV.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KV.Data.Repository
{
    public class AutorRepository : IAutorRepository
    {
        private readonly KvContext context;

        public AutorRepository(KvContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Autor>> GetAutoresAsync()
        {
            return await context.Autores
                //.Include(x => x.Endereco)
                //.Include(x => x.Telefones)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Autor> GetAutorAsync(int id)
        {
            return await context.Autores.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Autor> InsertAutorAsync(Autor novoAutor)
        {
            await context.Autores.AddAsync(novoAutor);
            await context.SaveChangesAsync();
            return novoAutor;
        }

        public async Task<Autor> UpdateAutorAsync(AlterarAutor autor)
        {
            var autorConsultada = await context.Autores
                                                 .FindAsync(autor.Id);

            context.Entry(autorConsultada).CurrentValues.SetValues(autor);

            await context.SaveChangesAsync();
            return autorConsultada;
        }

        //Delete
        public async Task<Autor> DeleteAutorAsync(int id)
        {
            var autorConsultado = await context.Autores.FindAsync(id);
            if (autorConsultado == null)
            {
                return null;
            }
            var autorRemovido = context.Autores.Remove(autorConsultado);
            await context.SaveChangesAsync();
            return autorRemovido.Entity;
        }
    }
}
