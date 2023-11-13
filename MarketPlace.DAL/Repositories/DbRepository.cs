using MarketPlace.DAL.Contexts;
using MarketPlace.DAL.Entities.Abstractions;
using MarketPlace.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL.Repositories
{
    public class DbRepository<T> : IDbRepository<T> where T : class, IEntity
    {
        private readonly MarketPlaceDbContext _context;

        public DbRepository(MarketPlaceDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsQueryable().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().AsQueryable().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task Update(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

