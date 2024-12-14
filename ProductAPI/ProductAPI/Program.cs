using Microsoft.EntityFrameworkCore;

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
                    Title = "My API",
                    Version = "v1",
                    Description = "A simple example API"
                });
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<Data.DataContext>(opt =>
            {
                opt.UseSqlServer("Server=DESKTOP-GE1ITJU;Database=ProductDB;User Id=racayouette; Password=Welcome123!;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}
