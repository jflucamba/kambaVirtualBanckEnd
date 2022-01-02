using AutoMapper;
using KV.Core.Domain;
using KV.Core.Shared.ModelView.SubCategoria;

namespace KV.Manager.Mappings
{
    public class NovaSubCategoriaMappingProfile : Profile
    {
        public NovaSubCategoriaMappingProfile()
        {
            CreateMap<NovaSubCategoria, SubCategoria>();
        }
    }
}