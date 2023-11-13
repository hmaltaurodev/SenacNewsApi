using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Domain.Entities
{
    public class Category : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;


        public ICollection<News> News { get; set; } = null!;
    }
}
