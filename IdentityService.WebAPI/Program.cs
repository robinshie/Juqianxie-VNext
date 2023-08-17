using CommonInitializer;
using IdentityService.Domain;
using IdentityService.Domain.Entities;
using IdentityService.Infrastructure;
using IdentityService.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IdentityService.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //string c = "Server = localhost;Database = demo1;User ID = SA;Password=rootXMHh123;TrustServerCertificate=True";
            //builder.Services.AddDbContext<IdDbContext>(options =>
            //options.UseSqlServer(c));
            
            builder.ConfigureExtraServices(new InitializerOptions
            {
                LogFilePath = "Logs/IdentityService.log",
                EventBusQueueName = "IdentityService.WebAPI"
            });
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "IdentityService.WebAPI", Version = "v1" });
                //c.AddAuthenticationHeader();
            });

            builder.Services.AddDataProtection();
            //��¼��ע�����Ŀ����Ҫ����WebApplicationBuilderExtensions�еĳ�ʼ��֮�⣬��Ҫ���µĳ�ʼ��
            //��Ҫ��AddIdentity��������AddIdentityCore
            //��Ϊ��AddIdentity�ᵼ��JWT���Ʋ������ã�AddJwtBearer�лص����ᱻִ�У��������AuthenticationУ��ʧ��
            //https://github.com/aspnet/Identity/issues/1376
            IdentityBuilder idBuilder = builder.Services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                //�����趨RequireUniqueEmail��������������Ϊ��
                //options.User.RequireUniqueEmail = true;
                //�������У���GenerateEmailConfirmationTokenAsync��֤������
                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
            }
            );
            idBuilder = new IdentityBuilder(idBuilder.UserType, typeof(Role), builder.Services);
            idBuilder.AddEntityFrameworkStores<IdDbContext>().AddDefaultTokenProviders()
            //.AddRoleValidator<RoleValidator<Role>>()
                .AddRoleManager<RoleManager<Role>>()
                .AddUserManager<IdUserManager>();

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddScoped<ISmsSender, MockSmsSender>();
            }
            else
            {
                builder.Services.AddScoped<ISmsSender, SendCloudSmsSender>();
            }
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (builder.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdentityService.WebAPI v1"));
            }
            app.UseJuqianxieDefault();
            app.MapControllers();
            app.Run();
        }
    }
}