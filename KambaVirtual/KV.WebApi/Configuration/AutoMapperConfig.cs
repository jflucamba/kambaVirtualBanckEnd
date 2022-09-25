using KV.Manager.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace KV.WebApi.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(NovaCategoriaMappingProfile),
                typeof(AlterarCategoriaMappingProfile),

                typeof(NovaSubCategoriaMappingProfile),
                typeof(AlterarSubCategoriaMappingProfile),

                typeof(NovoAutorMappingProfile),
                typeof(AlterarAutorMappingProfile));

        }
    }
}