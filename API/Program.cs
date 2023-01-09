using System;
using API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program // Every C# program starts with a "Program" class.
    {
        public static void Main(string[] args) // Ever C# program have Main method
        {
            /**
            All webapi must be hosted on a server either on a localhost or on a host somwhere else.
            .Net includes a server we can use to run our API, the server is called "Kestral".
            */
            var host = CreateHostBuilder(args).Build(); // Creating Kestral server with some default settings.Build it. Run it. In that order.

            /** Populate the database from DbInitializer.cs*/
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
