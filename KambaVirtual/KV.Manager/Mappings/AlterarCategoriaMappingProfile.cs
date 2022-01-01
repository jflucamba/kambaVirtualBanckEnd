using AutoMapper;
using KV.Core.Domain;
using KV.Core.Shared.ModelView.Categoria;

namespace KV.Manager.Mappings
{
    public class AlterarCategoriaMappingProfile : Profile
    {
        public AlterarCategoriaMappingProfile()
        {
            CreateMap<AlterarCategoria, Categoria>();
        }
    }
}