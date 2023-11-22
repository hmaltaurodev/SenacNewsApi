using SenacNews.Application.Commands;
using SenacNews.Application.Commands.CategoryCommands;
using SenacNews.Domain.Entities;
using SenacNews.Domain.Interfaces.Repositories;
using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Application.Handlers
{
    public class CategoryHandler : IHandler
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<ICommandResult> Handle(NewCategoryCommand command)
        {
            try
            {
                Category category = new Category()
                {
                    Name = command.Name
                };

                (category, int result) = await categoryRepository.Insert(category);

                if (result == 0)
                    return new CommandResult(false, "Não foi possível criar a Categoria!", category, 400);

                return new CommandResult(true, "Categoria criada com sucesso!", category);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, null, 500);
            }
        }

        public async Task<ICommandResult> Handle(UpdateCategoryCommand command)
        {
            try
            {
                Category? category = await categoryRepository.Select(command.Id);

                if (category is null)
                    return new CommandResult(false, "Categoria não encontrada!", null, 404);

                category.Name = command.Name;

                (category, int result) = await categoryRepository.Update(category);

                if (result == 0)
                    return new CommandResult(false, "Não foi possível atualizar a Categoria!", category, 400);

                return new CommandResult(true, "Categoria atualizada com sucesso!", category);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, null, 500);
            }
        }
    }
}
