using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Data.DataContext>(opt =>
            {
                opt.UseSqlServer("Server=DESKTOP-GE1ITJU;Database=ProductDB;User Id=racayouette; Password=Welcome123!;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
            });
            /*
              var serviceProvider = new ServiceCollection()
            .AddDbContext<QuizDbContext>(options =>
                options.UseSqlServer("Server=DESKTOP-GE1ITJU;Database=QuizDB;User Id=racayouette; Password=Welcome123!;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;"))
            .BuildServiceProvider();
             */


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
