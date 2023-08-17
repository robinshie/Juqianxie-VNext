using FileService.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Swashbuckle.AspNetCore.Swagger;
using CommonInitializer;
using Microsoft.Extensions.Configuration;
using FileService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FileService.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.ConfigureDbConfiguration();
            //builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.ConfigureExtraServices(new InitializerOptions
            {
                LogFilePath = "Logs/FileService.log"
            });

            string WorkingDir = JsonConvert.SerializeObject (new SMBStorageOptions() { WorkingDir = "/temp/temp" });
            // Add services to the container.
            builder.Services.AddOptions() //asp.net core项目中AddOptions()不写也行，因为框架一定自动执行了

                .Configure<SMBStorageOptions>(builder.Configuration.GetSection(WorkingDir));

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "FileService.WebAPI", Version = "v1" });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (builder.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FileService.WebAPI v1"));
            }
            app.UseStaticFiles();
            app.UseJuqianxieDefault();

            app.MapControllers();

            app.Run();
        }
    }
}