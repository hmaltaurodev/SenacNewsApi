using Microsoft.EntityFrameworkCore;
using SenacNews.Domain.Entities;

namespace SenacNews.Infra.Context
{
    public class SenacNewsContext : DbContext
    {
        public SenacNewsContext(DbContextOptions<SenacNewsContext> options)
            : base(options)
        { }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<News> News { get; set; }
    }
}
