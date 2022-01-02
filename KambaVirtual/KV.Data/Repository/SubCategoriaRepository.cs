using KV.Core.Domain;
using KV.Core.Shared.ModelView.SubCategoria;
using KV.Data.Context;
using KV.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KV.Data.Repository
{
    public class SubCategoriaRepository : ISubCategoriaRepository
    {
        private readonly KvContext context;

        public SubCategoriaRepository(KvContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SubCategoria>> GetSubCategoriasAsync()
        {
            return await context.SubCategorias
                //.Include(x => x.Endereco)
                //.Include(x => x.Telefones)
                .AsNoTracking().ToListAsync();
        }

        public async Task<SubCategoria> GetSubCategoriaAsync(int id)
        {
            return await context.SubCategorias.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<SubCategoria> InsertSubCategoriaAsync(SubCategoria nova)
        {
            await context.SubCategorias.AddAsync(nova);
            await context.SaveChangesAsync();
            return nova;
        }

        public async Task<SubCategoria> UpdateSubCategoriaAsync(AlterarSubCategoria alterar)
        {
            var consulta = await context.SubCategorias
                                                 .FindAsync(alterar.Id);
            //if (clienteConsultado == null)
            //{
            //    return null;
            //}

            context.Entry(consulta).CurrentValues.SetValues(alterar);

            //clienteConsultado.Endereco = categoria.Endereco;
            //UpdateClienteTelefones(categoria, clienteConsultado);

            await context.SaveChangesAsync();
            return consulta;
        }

        //Delete
        public async Task<SubCategoria> DeleteSubCategoriaAsync(int id)
        {
            var consultar = await context.SubCategorias.FindAsync(id);
            if (consultar == null)
            {
                return null;
            }
            var subCategoriaRemovida = context.SubCategorias.Remove(consultar);
            await context.SaveChangesAsync();
            return subCategoriaRemovida.Entity;
        }
    }
}