using KV.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace KV.WebApi.Configuration
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KvContext>(options =>
                options.UseMySql(configuration.GetConnectionString("KvConnection"),
                new MySqlServerVersion(new Version())));
        }

        public static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<KvContext>();
            context.Database.Migrate();
            context.Database.EnsureCreated();
        }
    }
}