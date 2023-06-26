    using Bai3.Db;

    namespace Bai3.Extensions
    {
        public static class WebApplicationExtensions
        {
            public static void MigrateDbContext(this WebApplication webApp)
            {
                using var scope = webApp.Services.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<Bai3DbContext>();
                var dataSeed = new Bai3DbContextSeed();
                dataSeed.SeedAsync(dbContext).Wait();
            }
        }
    }
