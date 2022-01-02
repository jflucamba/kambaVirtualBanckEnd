using AutoMapper;
using KV.Core.Domain;
using KV.Core.Shared.ModelView.SubCategoria;

namespace KV.Manager.Mappings
{
    public class AlterarSubCategoriaMappingProfile : Profile
    {
        public AlterarSubCategoriaMappingProfile()
        {
            CreateMap<AlterarSubCategoria, SubCategoria>();
        }
    }
}