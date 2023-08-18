using CommonInitializer;
using IdentityService.Domain;
using Juqianxie.Commons;
using Microsoft.Extensions.DependencyInjection;


namespace IdentityService.Infrastructure
{
    class ModuleInitializer : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<IProtectService, ProtectService>();
            services.AddScoped<ProtectAtribuild>();
            services.AddScoped<IdDomainService>();
            services.AddScoped<IIdRepository, IdRepository>();
        }
    }
}