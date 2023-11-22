using SenacNews.Application.Commands;
using SenacNews.Application.Commands.NewsCommands;
using SenacNews.Domain.Entities;
using SenacNews.Domain.Interfaces.Repositories;
using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Application.Handlers
{
    public class NewsHandler : IHandler
    {
        private readonly INewsRepository newsRepository;

        public NewsHandler(INewsRepository newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public async Task<ICommandResult> Handle(NewNewsCommand command)
        {
            try
            {
                News news = new News()
                {
                    Title = command.Title,
                    SubTitle = command.SubTitle,
                    Body = command.Body,
                    ImageUrl = command.ImageUrl,
                    AuthorId = command.AuthorId,
                    CategoryId = command.CategoryId
                };

                (news, int result) = await newsRepository.Insert(news);

                if (result == 0)
                    return new CommandResult(false, "Não foi possível criar a Notícia!", news, 400);

                return new CommandResult(true, "Notícia criada com sucesso!", news);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, null, 500);
            }
        }

        public async Task<ICommandResult> Handle(UpdateNewsCommand command)
        {
            try
            {
                News? news = await newsRepository.Select(command.Id);

                if (news is null)
                    return new CommandResult(false, "Notícia não encontrada!", null, 404);

                news.Title = command.Title;
                news.SubTitle = command.SubTitle;
                news.Body = command.Body;
                news.ImageUrl = command.ImageUrl;
                news.AuthorId = command.AuthorId;
                news.CategoryId = command.CategoryId;

                (news, int result) = await newsRepository.Update(news);

                if (result == 0)
                    return new CommandResult(false, "Não foi possível atualizar a Notícia!", news, 400);

                return new CommandResult(true, "Notícia atualizada com sucesso!", news);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, ex.Message, null, 500);
            }
        }
    }
}
