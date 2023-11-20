using Microsoft.EntityFrameworkCore;
using SenacNews.Infra.Context;

namespace SenacNews.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string? connectionString = builder.Configuration.GetConnectionString("Homolog");

            builder.Services.AddDbContext<SenacNewsContext>(opt =>
                opt.UseSqlServer(connectionString));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}