using Juqianxie.Commons;
using Microsoft.Extensions.DependencyInjection;


namespace Juqianxie.JWT
{
    class ModuleInitializer : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
