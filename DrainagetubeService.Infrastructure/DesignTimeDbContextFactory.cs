
using CommonInitializer;
using DrainagetubeService.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;

namespace DrainagetubeService.Infrastructure
{

    //用IDesignTimeDbContextFactory坑最少，最省事
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DrainageDbContext>
    {
        public DrainageDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = DbContextOptionsBuilderFactory.Create<DrainageDbContext>();
            return new DrainageDbContext(optionsBuilder.Options, null);
        }
    }
}