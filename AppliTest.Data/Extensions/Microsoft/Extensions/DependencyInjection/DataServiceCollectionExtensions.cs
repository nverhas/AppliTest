using AppliTest.Data.Context;
using AppliTest.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddAppliTestDatabase(
                                   this IServiceCollection services,
                                   IConfiguration configuration)
        {
            var migrationsAssembly = typeof(AppliTestDbContext).GetTypeInfo().Assembly.GetName().Name;
            var connectionString = configuration.GetConnectionString("AppliTest");
            var dbContextOptionsBuilder = new Action<DbContextOptionsBuilder>(builder =>
            {
                builder.UseSqlServer(connectionString, options =>
                {
                    options.MigrationsAssembly(migrationsAssembly);
                    options.CommandTimeout(180);
                });
            });

            return services
                .AddDbContext<AppliTestDbContext>(dbContextOptionsBuilder, ServiceLifetime.Scoped)
                .AddScoped<AppliTestDbContext, AppliTestDbContext>();
        }

        /// <summary>
        /// Ajoute les services à l'injecteur de dépendances
        /// </summary>
        /// <param name="services">L'interface d'enregistrement de l'injecteur
        /// de dépendances</param>
        /// <returns>L'interface d'enregistrement de l'injecteur de dépendances</returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IPersonneRepository, PersonneRepository>()
                ;

        }
    }
}
