using SenacNews.Application.Commands;
using SenacNews.Application.Commands.AuthorCommands;
using SenacNews.Domain.Entities;
using SenacNews.Domain.Interfaces.Repositories;
using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Application.Handlers
{
    public class AuthorHandler : IHandler
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorHandler(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public async Task<ICommandResult> Handle(NewAuthorCommand command)
        {
            try
            {
                Author author = new Author()
                {
                    Name = command.Name,
                    Email = command.Email
                };

                (author, int result) = await authorRepository.Insert(author);

                if (result == 0)
                    return new CommandResult(false, "Não foi possível criar o Autor!", author, 400);

                return new CommandResult(true, "Autor criado com sucesso!", author);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, null, 500);
            }
        }

        public async Task<ICommandResult> Handle(UpdateAuthorCommand command)
        {
            try
            {
                Author? author = await authorRepository.Select(command.Id);

                if (author is null)
                    return new CommandResult(false, "Autor não encontrado!", null, 404);

                author.Name = command.Name;
                author.Email = command.Email;

                (author, int result) = await authorRepository.Update(author);

                if (result == 0)
                    return new CommandResult(false, "Não foi possível atualizar o Autor!", author, 400);

                return new CommandResult(true, "Autor atualizado com sucesso!", author);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, null, 500);
            }
        }
    }
}
