using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Application.Commands.AuthorCommands
{
    public class NewAuthorCommand : ICommand
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}
