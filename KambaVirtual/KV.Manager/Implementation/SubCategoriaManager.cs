using AutoMapper;
using KV.Core.Domain;
using KV.Core.Shared.ModelView.SubCategoria;
using KV.Manager.Interfaces.Managers;
using KV.Manager.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KV.Manager.Implementation
{
    public class SubCategoriaManager : ISubCategoriaManager
    {
        private readonly ISubCategoriaRepository repository;
        private readonly IMapper mapper;

        public SubCategoriaManager(ISubCategoriaRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task DeleteSubCategoriaAsync(int id)
        {
            var categoria = await repository.DeleteSubCategoriaAsync(id);
        }

        public async Task<SubCategoria> GetSubCategoriaAsync(int id)
        {
            return await repository.GetSubCategoriaAsync(id);
        }

        public async Task<IEnumerable<SubCategoria>> GetSubCategoriasAsync()
        {
            return await repository.GetSubCategoriasAsync();
        }

        public async Task<SubCategoria> InsertSubCategoriaAsync(NovaSubCategoria novaCategoria)
        {
            var categoria = mapper.Map<SubCategoria>(novaCategoria);
            return await repository.InsertSubCategoriaAsync(categoria);
        }

        public async Task<SubCategoria> UpdateSubCategoriaAsync(AlterarSubCategoria alterar)
        {
            var categoria = mapper.Map<SubCategoria>(alterar);
            return await repository.UpdateSubCategoriaAsync(alterar);
        }
    }
}