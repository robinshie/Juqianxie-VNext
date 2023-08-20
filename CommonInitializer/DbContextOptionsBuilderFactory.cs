using Microsoft.EntityFrameworkCore;

namespace CommonInitializer
{
    public static class DbContextOptionsBuilderFactory
    {
        public static DbContextOptionsBuilder<TDbContext> Create<TDbContext>()
            where TDbContext : DbContext
        {
            var connStr = Environment.GetEnvironmentVariable("DefaultDBConnStr");
            var optionsBuilder = new DbContextOptionsBuilder<TDbContext>();
            optionsBuilder.UseSqlServer(connStr);
            return optionsBuilder;
        }
    }
}
