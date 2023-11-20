using SenacNews.Domain.Entities;
using SenacNews.Domain.Interfaces.Repositories;
using SenacNews.Infra.Context;

namespace SenacNews.Infra.Repositories
{
    public class CategoryRepository : Repository<Category, SenacNewsContext>, ICategoryRepository
    {
        public CategoryRepository(SenacNewsContext context) : base(context)
        { }
    }
}
