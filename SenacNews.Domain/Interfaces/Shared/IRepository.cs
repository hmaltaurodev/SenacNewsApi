namespace SenacNews.Domain.Interfaces.Shared
{
    public interface IRepository<T> where T : class, IEntity
    {
        public Task<List<T>> SelectAll();

        public Task<T?> Select(Guid id);

        public Task<(T?, int)> Delete(Guid id);

        public Task<(T, int)> Insert(T entity);

        public Task<(T, int)> Update(T entity);
    }
}
