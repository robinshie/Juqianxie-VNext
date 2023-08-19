﻿using Juqianxie.Commons;
using Microsoft.Extensions.DependencyInjection;
using DrainagetubeService.Domain;
namespace DrainagetubeService.Infrastructure
{
    class ModuleInitializer : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<IDrainagetubeRepository, DrainagetubeRepository>();
            services.AddScoped<IDrainagetubeDomainService, DrainagetubeDomainService>();
            services.AddScoped<IDrainageLiquidRepository, DrainageLiquidRepository>();
            services.AddScoped<IDrainageLiquidDomainService, DrainageLiquidDomainService>();
        }
    }
}