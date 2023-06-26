using Demo.Db;
using System.Runtime.CompilerServices;

namespace Demo.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void MigrateDbContext(this WebApplication webApp)
        {
            using var scope = webApp.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DemoDbContext>();
            var dataSeed = new DemoDbContextSeed();
            dataSeed.SeedAsync(dbContext).Wait();
        }
        
    }
}
