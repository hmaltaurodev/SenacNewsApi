using SenacNews.Domain.Entities;
using SenacNews.Domain.Interfaces.Repositories;
using SenacNews.Infra.Context;

namespace SenacNews.Infra.Repositories
{
    public class AuthorRepository : Repository<Author, SenacNewsContext>, IAuthorRepository
    {
        public AuthorRepository(SenacNewsContext context) : base (context)
        { }
    }
}
