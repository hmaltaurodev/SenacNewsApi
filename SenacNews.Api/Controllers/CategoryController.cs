using Microsoft.AspNetCore.Mvc;
using SenacNews.Application.Commands;
using SenacNews.Application.Commands.CategoryCommands;
using SenacNews.Application.Handlers;
using SenacNews.Domain.Entities;
using SenacNews.Domain.Interfaces.Repositories;

namespace SenacNews.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : DefaultController<Category, ICategoryRepository>
    {
        public CategoryController(ICategoryRepository repository) : base(repository)
        { }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add([FromBody] NewCategoryCommand command, [FromServices] CategoryHandler handler)
        {
            CommandResult result = (CommandResult)await handler.Handle(command);
            return result.Success ? Created("", result) : StatusCode(result.StatusCode ?? 400, result);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand command, [FromServices] CategoryHandler handler)
        {
            CommandResult result = (CommandResult)await handler.Handle(command);
            return result.Success ? Ok(result) : StatusCode(result.StatusCode ?? 400, result);
        }
    }
}
