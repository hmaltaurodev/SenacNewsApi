using Microsoft.AspNetCore.Mvc;
using SenacNews.Application.Commands;
using SenacNews.Application.Commands.AuthorCommands;
using SenacNews.Application.Handlers;
using SenacNews.Domain.Entities;
using SenacNews.Domain.Interfaces.Repositories;

namespace SenacNews.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : DefaultController<Author, IAuthorRepository>
    {
        public AuthorController(IAuthorRepository repository) : base(repository)
        { }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] NewAuthorCommand command, [FromServices] AuthorHandler handler)
        {
            CommandResult result = (CommandResult) await handler.Handle(command);
            return result.Success ? Created("", result) : StatusCode(result.StatusCode ?? 400, result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorCommand command, [FromServices] AuthorHandler handler)
        {
            CommandResult result = (CommandResult)await handler.Handle(command);
            return result.Success ? Ok(result) : StatusCode(result.StatusCode ?? 400, result);
        }
    }
}
