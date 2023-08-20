
using CommonInitializer;
using DrainagetubeService.Infrastructure;
using IdentityService.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;

namespace DrainagetubeService.Infrastructure
{

    //用IDesignTimeDbContextFactory坑最少，最省事
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdDbContext>
    {
        public IdDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = DbContextOptionsBuilderFactory.Create<IdDbContext>();
            return new IdDbContext(optionsBuilder.Options);
        }
    }
}