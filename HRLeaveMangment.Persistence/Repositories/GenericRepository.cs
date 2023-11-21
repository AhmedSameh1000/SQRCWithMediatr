using HRLeaveMangment.Application.Contracts.persistence;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveMangment.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HRLeaveMangmentDbContext _dbContext;

        public GenericRepository(HRLeaveMangmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int Id)
        {
            var Entity = await GetAsync(Id);
            return Entity != null;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var Entities = await _dbContext.Set<T>().ToListAsync();
            return Entities;
        }

        public async Task<T> GetAsync(int Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}