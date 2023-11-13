using MarketPlace.DAL.Entities.Abstractions;

namespace MarketPlace.DAL.Repositories.Abstractions
{
    public interface IDbRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}

