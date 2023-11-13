using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Domain.Entities
{
    public class Author : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;


        public ICollection<News> News { get; set; } = null!;
    }
}
