using InmobiliariaAPI.Models.DTOs;
using System.Linq.Expressions;

namespace InmobiliariaAPI.Data.Repositories;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    Task<PagedResponse<T>> GetPagedAsync(int page, int pageSize, Expression<Func<T, bool>>? predicate = null);
}
