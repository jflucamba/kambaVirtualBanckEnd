using KV.Core.Domain;
using KV.Data.Context;
using KV.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KV.Data.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly KvContext context;

        public CategoriaRepository(KvContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            return await context.Categorias
                //.Include(x => x.Endereco)
                //.Include(x => x.Telefones)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Categoria> GetCategoriaAsync(int id)
        {
            return await context.Categorias.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Categoria> InsertCategoriaAsync(Categoria novaCategoria)
        {
            await context.Categorias.AddAsync(novaCategoria);
            await context.SaveChangesAsync();
            return novaCategoria;
        }

        public async Task<Categoria> UpdateCategoriaAsync(Categoria categoria)
        {
            var clienteConsultado = await context.Categorias
                                                 //.Include(p => p.Endereco)
                                                 //.Include(p => p.Telefones)
                                                 .FirstOrDefaultAsync(p => p.Id == categoria.Id);
            //if (clienteConsultado == null)
            //{
            //    return null;
            //}
            //context.Entry(clienteConsultado).CurrentValues.SetValues(categoria);
            //clienteConsultado.Endereco = categoria.Endereco;
            //UpdateClienteTelefones(categoria, clienteConsultado);
            await context.SaveChangesAsync();
            return clienteConsultado;
        }

        //Delete
        public async Task<Categoria> DeleteClienteAsync(int id)
        {
            var categoriaConsultada = await context.Categorias.FindAsync(id);
            if (categoriaConsultada == null)
            {
                return null;
            }
            var categoriaRemovida = context.Categorias.Remove(categoriaConsultada);
            await context.SaveChangesAsync();
            return categoriaRemovida.Entity;
        }

    }
}
