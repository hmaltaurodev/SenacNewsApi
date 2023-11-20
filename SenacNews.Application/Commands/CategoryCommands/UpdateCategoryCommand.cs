using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Application.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
