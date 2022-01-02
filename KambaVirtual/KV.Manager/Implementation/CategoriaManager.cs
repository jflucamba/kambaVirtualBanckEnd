using AutoMapper;
using KV.Core.Domain;
using KV.Core.Shared.ModelView.Categoria;
using KV.Manager.Interfaces.Managers;
using KV.Manager.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KV.Manager.Implementation
{
    public class CategoriaManager : ICategoriaManager
    {
        private readonly ICategoriaRepository repository;
        private readonly IMapper mapper;

        public CategoriaManager(ICategoriaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task DeleteCategoriaAsync(int id)
        {
            var categoria = await repository.DeleteCategoriaAsync(id);
            //return mapper.Map<>
        }

        public async Task<Categoria> GetCategoriaAsync(int id)
        {
            return await repository.GetCategoriaAsync(id);
        }

        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            return await repository.GetCategoriasAsync();
        }

        public async Task<Categoria> InsertCategoriaAsync(NovaCategoria novaCategoria)
        {
            var categoria = mapper.Map<Categoria>(novaCategoria);
            return await repository.InsertCategoriaAsync(categoria);
        }

        public async Task<Categoria> UpdateCategoriaAsync(AlterarCategoria alterarCategoria)
        {
            var categoria = mapper.Map<Categoria>(alterarCategoria);
            return await repository.UpdateCategoriaAsync(alterarCategoria);
        }
    }
}