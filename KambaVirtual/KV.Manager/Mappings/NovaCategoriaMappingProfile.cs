using AutoMapper;
using KV.Core.Domain;
using KV.Core.Shared.ModelView.Categoria;

namespace KV.Manager.Mappings
{
    public class NovaCategoriaMappingProfile : Profile
    {
        public NovaCategoriaMappingProfile()
        {
            CreateMap<NovaCategoria, Categoria>();
        }
    }
}