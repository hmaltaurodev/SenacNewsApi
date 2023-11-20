using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Application.Commands.AuthorCommands
{
    public class UpdateAuthorCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
