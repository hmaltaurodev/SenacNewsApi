using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Application.Commands.NewsCommands
{
    public class NewNewsCommand : ICommand
    {
        public string Title { get; set; } = null!;

        public string SubTitle { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Body { get; set; } = null!;

        public Guid CategoryId { get; set; }

        public Guid AuthorId { get; set; }
    }
}
