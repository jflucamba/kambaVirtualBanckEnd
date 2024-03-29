﻿using KV.Core.Domain;
using KV.Core.Shared.ModelView.Categoria;
using KV.Data.Context;
using KV.Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<Categoria> UpdateCategoriaAsync(AlterarCategoria categoria)
        {
            var categoriaConsultada = await context.Categorias
                                                 //.Include(p => p.Endereco)
                                                 //.Include(p => p.Telefones)
                                                 .FindAsync(categoria.Id);
            //if (clienteConsultado == null)
            //{
            //    return null;
            //}

            context.Entry(categoriaConsultada).CurrentValues.SetValues(categoria);

            //clienteConsultado.Endereco = categoria.Endereco;
            //UpdateClienteTelefones(categoria, clienteConsultado);

            await context.SaveChangesAsync();
            return categoriaConsultada;
        }

        //Delete
        public async Task<Categoria> DeleteCategoriaAsync(int id)
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