using Microsoft.EntityFrameworkCore;
using SenacNews.Application.Handlers;
using SenacNews.Domain.Interfaces.Repositories;
using SenacNews.Infra.Context;
using SenacNews.Infra.Repositories;
using System.Text.Json.Serialization;

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

            builder.Services.AddDbContext<SenacNewsContext>(opt => opt.UseSqlServer(connectionString));
            builder.Services.AddControllers().AddJsonOptions(opt =>
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddScoped<AuthorHandler>();
            builder.Services.AddScoped<CategoryHandler>();
            builder.Services.AddScoped<NewsHandler>();

            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<INewsRepository, NewsRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}