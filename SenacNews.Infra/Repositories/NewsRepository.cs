using SenacNews.Domain.Entities;
using SenacNews.Domain.Interfaces.Repositories;
using SenacNews.Infra.Context;

namespace SenacNews.Infra.Repositories
{
    public class NewsRepository : Repository<News, SenacNewsContext>, INewsRepository
    {
        public NewsRepository(SenacNewsContext context) : base(context)
        { }
    }
}
