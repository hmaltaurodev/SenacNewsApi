using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Infra.Repositories
{
    public abstract class Repository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, IEntity
                                                                               where TContext : DbContext
    {
        protected readonly TContext context;

        public Repository(TContext context)
        {
            this.context = context;
        }

        public virtual async Task<List<TEntity>> SelectAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity?> Select(Guid id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<(TEntity?, int)> Delete(Guid id)
        {
            TEntity? entity = await context.Set<TEntity>().FindAsync(id);
            if (entity is null)
                return (null, 1);

            context.Set<TEntity>().Remove(entity);
            int result = await context.SaveChangesAsync();
            return (entity, result);
        }

        public virtual async Task<(TEntity, int)> Insert(TEntity entity)
        {
            EntityEntry<TEntity> entry = context.Set<TEntity>().Add(entity);
            int result = await context.SaveChangesAsync();
            return (entry.Entity, result);
        }

        public virtual async Task<(TEntity, int)> Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            int result = await context.SaveChangesAsync();
            return (entity, result);
        }
    }
}
