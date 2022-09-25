using AutoMapper;
using KV.Core.Domain;
using KV.Core.Shared.ModelView.Autor;
using KV.Manager.Interfaces.Managers;
using KV.Manager.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KV.Manager.Implementation
{
    public class AutorManager : IAutorManager
    {
        private readonly IAutorRepository repository;
        private readonly IMapper mapper;

        public AutorManager(IAutorRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task DeleteAutorAsync(int id)
        {
            var autor = await repository.DeleteAutorAsync(id);
        }

        public async Task<Autor> GetAutorAsync(int id)
        {
            return await repository.GetAutorAsync(id);
        }

        public async Task<IEnumerable<Autor>> GetAutoresAsync()
        {
            return await repository.GetAutoresAsync();
        }

        public async Task<Autor> InsertAutorAsync(NovoAutor novoAutor)
        {
            var autor = mapper.Map<Autor>(novoAutor);
            return await repository.InsertAutorAsync(autor);
        }

        public async Task<Autor> UpdateAutorAsync(AlterarAutor alterarAutor)
        {
            var autor = mapper.Map<Autor>(alterarAutor);
            return await repository.UpdateAutorAsync(alterarAutor);
        }
    }
}
