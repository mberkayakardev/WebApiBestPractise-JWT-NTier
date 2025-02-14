using Core.Entities.Abstract;
using System.Linq.Expressions;
using TrendMusic.ECommerce.Core.Utilities.Pagination.ComplexTypes;

namespace Core.Repositories.EntityFramework.Abstract
{
    public interface IEfGenericRepositories <T> where T : class, IEntity, new()
    {
        Task<T> CreateAsync(T Entity); 
        Task UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
        Task SoftDeleteAsync(T Entity);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null, bool AsNoTracking = true, Expression<Func<T, object>> OrderByProperty = null, params Expression<Func<T, object>>[] IncludeProperties);
        Task<List<T>> GetAllAsyncWithListExpression(IList<Expression<Func<T, bool>>> where = null, bool AsNoTracking = true, Expression<Func<T, object>> OrderByProperty = null, params Expression<Func<T, object>>[] IncludeProperties); 
        Task<PagedList<T>> GetAllWithPagingAsync(RequestParameters parameters, Expression<Func<T, bool>> where = null, bool AsNoTracking = true, Expression<Func<T, object>> OrderByProperty = null, params Expression<Func<T, object>>[] IncludeProperties);
        Task<PagedList<T>> GetAllWithPagingAsync(RequestParameters parameters, IList<Expression<Func<T, bool>>> where = null, bool AsNoTracking = true, Expression<Func<T, object>> OrderByProperty = null,  params Expression<Func<T, object>>[] IncludeProperties);  
        Task<T> GetAsync(Expression<Func<T, bool>> where = null, bool AsNoTracking = false, Expression<Func<T, object>> OrderBy = null, params Expression<Func<T, object>>[] IncludeProperties);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAsQueryable();
    }
}
