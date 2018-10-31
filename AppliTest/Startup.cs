using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppliTest
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //Configuration de MVC (map routes)
            services.AddMvc(options =>
            {
                // Filtres globaux : SSL, Authorize, Antiforgery (XSRF), Security headers
                // a ajouter ici
            });

            services.AddSingleton<IConfiguration>(Configuration);
            //Migration BDD
            services.AddAppliTestDatabase(Configuration);

            services
                // DependencyInjection
                .AddRepositories();

            //augmente le nombre de champs max que peut contenir une form, par défaut cette limite est à 1024
            services.Configure<FormOptions>(options => { options.ValueCountLimit = 10240; });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "areaRoute",
                //    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/");
            });
            
        }
    }
}
