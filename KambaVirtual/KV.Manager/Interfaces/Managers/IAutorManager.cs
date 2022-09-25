﻿using KV.Core.Domain;
using KV.Core.Shared.ModelView.Autor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KV.Manager.Interfaces.Managers
{
    public interface IAutorManager
    {
        Task DeleteAutorAsync(int id);
        Task<Autor> GetAutorAsync(int id);
        Task<IEnumerable<Autor>> GetAutoresAsync();
        Task<Autor> InsertAutorAsync(NovoAutor novoAutor);
        Task<Autor> UpdateAutorAsync(AlterarAutor autor);
    }
}
