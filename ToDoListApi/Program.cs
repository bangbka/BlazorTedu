using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ToDoListApi.Data;
using ToDoListApi.Extensions;

namespace ToDoListApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDbContext<ToDoListDbContext>((context, services) =>
            {
                var logger = services.GetService<ILogger<ToDoListDbContextSeed>>();
                new ToDoListDbContextSeed().SeedAsync(context, logger).Wait();
            });
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
