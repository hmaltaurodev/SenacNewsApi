using Microsoft.EntityFrameworkCore;
using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Domain.Entities
{
    public class News : IEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string SubTitle { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Body { get; set; } = null!;

        public DateTime PublicationDate { get; set; } = DateTime.Now;

        public Guid CategoryId { get; set; }

        public Guid AuthorId { get; set; }


        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Category? Category { get; set; }

        [DeleteBehavior(DeleteBehavior.Restrict)]
        public Author? Author { get; set; }
    }
}
