using Microsoft.AspNetCore.Mvc;
using SenacNews.Application.Commands;
using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Api.Controllers
{
    public abstract class DefaultController<TEntity, TRepository> : ControllerBase where TEntity : class, IEntity
                                                                                   where TRepository : class, IRepository<TEntity>
    {
        protected readonly TRepository repository;

        public DefaultController(TRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("List")]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            return Ok(await repository.SelectAll());
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<ActionResult<TEntity>> Get(Guid id)
        {
            TEntity? entity = await repository.Select(id);
            return (entity is null) ? NotFound() : Ok(entity);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task<ActionResult<TEntity>> Delete(Guid id)
        {
            try
            {
                (TEntity? entity, int result) = await repository.Delete(id);

                if (result == 0)
                    return BadRequest(new CommandResult(false, "Não foi possível deletar o registro!"));

                return (entity is null) ? NoContent() : Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new CommandResult(false, ex.Message));
            }
        }
    }
}
