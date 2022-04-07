
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using shared.DatabaseContext;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using WebApi.Middleware;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configuración de Sql Server en memoria
            //services.AddDbContext<WebApiDbContext>(options => options.UseInMemoryDatabase(databaseName: "Patterns_DB"));
            services.AddDbContext<WebApiDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("masterDb")));
            services.AddSwaggerGen();
            services.AddControllers();
            
            //Adds singleton, trasient or scoped types implemented     
            services.AddServicesOfAllTypes();

            // Inyección de los servicios
            IoC.AddDependency(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
