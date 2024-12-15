using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ProductAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "ProductAPI",
                    Version = "v1",
                    Description = "A simple example to learning"
                });
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<Data.DataContext>(opt =>
            {
                // TODO: encrypt password and store in the appsettings.json
                opt.UseSqlServer("Server=DESKTOP-GE1ITJU;Database=ProductDB;User Id=racayouette; Password=Welcome123!;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
                
                // use this to ignore warning when updating the database migration error cause with .net 9 bug - 2024-12-14
                // https://github.com/dotnet/efcore/issues/34431
                opt.ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning));
            });
            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
                .WithOrigins("http://localhost:4200", "https://localhost:4200"));

            app.MapControllers();

            app.Run();
        }
    }
}
