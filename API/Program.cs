/** Importera in dom biblioteken som behövs*/
using System;
using API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program // All C# Program har Main class 
    {
        public static void Main(string[] args)
        {
            /** 
            * Webapi fungerar som en middleware för att förmedla datan från .Net till React 
            * Denna princip appliceras också i headless utveckling fast då är det med GraphQL eller REST istället
            */
            var host = CreateHostBuilder(args).Build(); // Skapa en kestrel server med några standard argumenter, bygg och kör.

            /** Populera databasen med tabeller från DbInitializer.cs*/
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            try
            {
                context.Database.Migrate();
                DbInitializer.Initialize(context);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Problem migrating data");
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => // CreateHostBuilder method is set up here. After the function call, thanks to hoisting.
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => // Configures with default settings.
                {
                    webBuilder.UseStartup<Startup>(); // Uses a "Startup" class for additional configurations.
                });
    }
}
