using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Application.Commands.CategoryCommands
{
    public class NewCategoryCommand : ICommand
    {
        public string Name { get; set; } = null!;
    }
}
