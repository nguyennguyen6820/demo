using Bai2.Models;

namespace Bai2.Db
{
    public class MyDbcontextSeed
    {
        public async Task SeedAsync(MyDbcontext context)
        {
            context.Database.EnsureCreated();
            if(!context.Student.Any())
            {

            }
        }
    }
}
