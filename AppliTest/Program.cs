using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppliTest.Data.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AppliTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope()) // pour DependencyInjection
            {
                var services = scope.ServiceProvider;
                services.MigrateDb().SeedData();  // seed de la base
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    // delete all default configuration providers
                    config.Sources.Clear();

                    IHostingEnvironment env = hostContext.HostingEnvironment;
                    config.AddEnvironmentVariables();
                    config.SetBasePath(env.ContentRootPath);
                    // fichiers de settings
                    config.AddJsonFile($"Settings\\{env.EnvironmentName}\\database.json", optional: true, reloadOnChange: true);
                    // voir Nlog pour le log de l'appli
                })

                .UseUrls("http://localhost:15010")

                .Build();
    }
}
