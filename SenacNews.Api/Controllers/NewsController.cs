using Microsoft.AspNetCore.Mvc;
using SenacNews.Application.Commands;
using SenacNews.Application.Commands.NewsCommands;
using SenacNews.Application.Handlers;
using SenacNews.Domain.Entities;
using SenacNews.Domain.Interfaces.Repositories;

namespace SenacNews.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : DefaultController<News, INewsRepository>
    {
        public NewsController(INewsRepository repository) : base(repository)
        { }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] NewNewsCommand command, [FromServices] NewsHandler handler)
        {
            CommandResult result = (CommandResult)await handler.Handle(command);
            return result.Success ? Created("", result) : StatusCode(result.StatusCode ?? 400, result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateNewsCommand command, [FromServices] NewsHandler handler)
        {
            CommandResult result = (CommandResult)await handler.Handle(command);
            return result.Success ? Ok(result) : StatusCode(result.StatusCode ?? 400, result);
        }
    }
}
