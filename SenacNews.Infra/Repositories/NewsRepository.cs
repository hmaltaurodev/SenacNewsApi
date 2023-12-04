using Microsoft.EntityFrameworkCore;
using SenacNews.Domain.Entities;
using SenacNews.Domain.Interfaces.Repositories;
using SenacNews.Domain.Interfaces.Shared;
using SenacNews.Infra.Context;

namespace SenacNews.Infra.Repositories
{
    public class NewsRepository : Repository<News, SenacNewsContext>, INewsRepository
    {
        public NewsRepository(SenacNewsContext context) : base(context)
        { }

        public override async Task<List<News>> SelectAll()
        {
            return await context.Set<News>()
                                .Include(n => n.Author)
                                .Include(n => n.Category)
                                .ToListAsync();
        }
    }
}
