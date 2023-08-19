using CommonInitializer;
using DrainagetubeService.Infrastructure;
using Juqianxie.JWT;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DrainagetubeService.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.ConfigureDbConfiguration();
            builder.ConfigureExtraServices(new InitializerOptions
            {
                LogFilePath = "Logs/DrainagetubeService.log",
                EventBusQueueName = "DrainagetubeService.WebAPI"
            });
            builder.Services.AddControllers();
            builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo("gen"));
            //builder.Services.AddScoped<IDataProtectionBuilder>();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "DrainagetubeService.WebAPI", Version = "v1" });
                //c.AddAuthenticationHeader();
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (builder.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DrainagetubeService.WebAPI v1"));
            }
            app.UseJuqianxieDefault();
            app.MapControllers();
            app.Run();
        }
    }
}
