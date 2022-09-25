using AutoMapper;
using KV.Core.Domain;
using KV.Core.Shared.ModelView.Autor;

namespace KV.Manager.Mappings
{
    public class NovoAutorMappingProfile : Profile
    {
        public NovoAutorMappingProfile()
        {
            CreateMap<NovoAutor, Autor>();
        }
    }
}
