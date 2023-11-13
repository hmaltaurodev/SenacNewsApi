using SenacNews.Domain.Entities;
using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Domain.Interfaces.Repositories
{
    public interface INewsRepository : IRepository<News>
    { }
}
