namespace HRLeaveMangment.Application.Contracts.persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int Id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<bool> Exist(int Id);

        Task<T> CreateAsync(T entity);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);
    }
}