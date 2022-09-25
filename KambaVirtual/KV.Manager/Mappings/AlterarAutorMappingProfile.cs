using AutoMapper;
using KV.Core.Domain;
using KV.Core.Shared.ModelView.Autor;

namespace KV.Manager.Mappings
{
    public class AlterarAutorMappingProfile : Profile
    {
        public AlterarAutorMappingProfile()
        {
            CreateMap<AlterarAutor, Autor>();
        }
    }
}
