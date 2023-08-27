using FileService.Domain;
using FileService.Infrastructure.Services;
using Juqianxie.Commons;
using Microsoft.Extensions.DependencyInjection;
namespace FileService.Infrastructure
{
    class ModuleInitializer : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<IStorageClient, SMBStorageClient>();
            services.AddScoped<IFSRepository, FSRepository>();
            services.AddScoped<IFondConfigsRepository, FondConfigsRepository>();
            services.AddScoped<FSDomainService>();
        }
    }
}
