using Bai4.Db;
using System.Runtime.CompilerServices;

namespace Bai4.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void MigrateDbContext(this WebApplication webApp)
        {
            using var scope = webApp.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<Bai4DbContext>();
            var dataSeed = new Bai4DbContextSeed();
            dataSeed.SeedAsync(dbContext).Wait();
        }
        
    }
}
