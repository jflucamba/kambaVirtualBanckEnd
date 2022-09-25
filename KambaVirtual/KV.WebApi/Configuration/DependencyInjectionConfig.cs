using KV.Data.Repository;
using KV.Manager.Implementation;
using KV.Manager.Interfaces.Managers;
using KV.Manager.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace KV.WebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ICategoriaManager, CategoriaManager>();

            services.AddScoped<ISubCategoriaRepository, SubCategoriaRepository>();
            services.AddScoped<ISubCategoriaManager, SubCategoriaManager>();

            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IAutorManager, AutorManager>();

        }
    }
}