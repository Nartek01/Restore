using API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            /** 
            * Den första metoden som körs när du instaniera klassen, kallas för constructor 
            * I php använder man syntaxen __construct
            */
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Denna metod instansieras av "Runtime", använd den när du ska lägga till "services" till containern
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddDbContext<StoreContext>(opt =>
            {
                opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            });
        }

        // Denna metod instansieras på runtime, Använd denna metod till för att konfigurera HTTP anrop.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
