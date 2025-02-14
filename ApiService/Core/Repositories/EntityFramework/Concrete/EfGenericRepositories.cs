using Core.Entities.Abstract;
using Core.Repositories.EntityFramework.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TrendMusic.ECommerce.Core.Utilities.Pagination.ComplexTypes;

namespace Core.Repositories.EntityFramework.Concrete
{
    public class EfGenericRepositories<T> : IEfGenericRepositories<T> where T : class, IEntity, new()
    {
        protected readonly DbContext _Context;
        protected readonly DbSet<T> _Entities;

        public EfGenericRepositories(DbContext context)
        {
            _Context = context;
            _Entities = _Context.Set<T>();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _Entities.AnyAsync(predicate);
            return result;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return (predicate == null) ? await _Entities.CountAsync() : await _Entities.CountAsync(predicate);
        }

        public async Task<T> CreateAsync(T Entity)
        {
            await _Entities.AddAsync(Entity);
            return Entity;
        }
        public async Task DeleteAsync(T Entity)
        {
            await Task.Run(() =>
            {
                _Entities.Remove(Entity);
            });
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where = null, bool AsNoTracking = true, Expression<Func<T, object>> OrderByProperty = null, params Expression<Func<T, object>>[] IncludeProperties)
        {
            IQueryable<T> query = _Entities;

            if (IncludeProperties != null)

                foreach (var item in IncludeProperties)
                    query = query.Include(item);

            if (where != null)
                query = query.Where(where);

            if (OrderByProperty != null)
            {
                
            }

            if (AsNoTracking == true)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<List<T>> GetAllAsyncWithListExpression(IList<Expression<Func<T, bool>>> where = null, bool AsNoTracking = true, Expression<Func<T, object>> OrderByProperty = null,  params Expression<Func<T, object>>[] IncludeProperties)
        {
            IQueryable<T> query = _Entities;

            if (IncludeProperties != null)

                foreach (var item in IncludeProperties)
                    query = query.Include(item);

            if (where != null)
                foreach (var item in where)
                    query = query.Where(item);


            if (OrderByProperty != null)
            {
                
            }

            if (AsNoTracking == true)
                query = query.AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<PagedList<T>> GetAllWithPagingAsync(RequestParameters parameters, Expression<Func<T, bool>> where = null, bool AsNoTracking = true, Expression<Func<T, object>> OrderByProperty = null, params Expression<Func<T, object>>[] IncludeProperties)
        {
            IQueryable<T> query = _Entities;

            if (IncludeProperties != null)

                foreach (var item in IncludeProperties)
                    query = query.Include(item);

            if (where != null)
                query = query.Where(where);

            if (OrderByProperty != null)
            {

            }

            if (AsNoTracking == true)
                query = query.AsNoTracking();

            #region GenericPaging
            var queryCount = query.Count(); // Total Nesne Sayısı 
            var Model = await query.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize).ToListAsync(); // seçilen sayfanın bir öncesi * sayfanın toplam içeriği ve sonrasında Take ile ne kadar alacağım burada belirlenmiştir. 
            #endregion
            return PagedList<T>.ToPagedList(Model, parameters.PageNumber, parameters.PageSize, queryCount);

        }

        public async Task<PagedList<T>> GetAllWithPagingAsync(RequestParameters parameters, IList<Expression<Func<T, bool>>> where = null, bool AsNoTracking = true, Expression<Func<T, object>> OrderByProperty = null, params Expression<Func<T, object>>[] IncludeProperties)
        {
            IQueryable<T> query = _Entities;

            if (IncludeProperties != null)

                foreach (var item in IncludeProperties)
                    query = query.Include(item);

            if (where != null)
                foreach (var item in where)
                {
                    query = query.Where(item);
                }

            if (OrderByProperty != null)
            {

            }

            if (AsNoTracking == true)
                query = query.AsNoTracking();

            #region GenericPaging
            var queryCount = query.Count(); // Total Nesne Sayısı 
            var Model = await query.Skip((parameters.PageNumber - 1) * parameters.PageSize).Take(parameters.PageSize).ToListAsync(); // seçilen sayfanın bir öncesi * sayfanın toplam içeriği ve sonrasında Take ile ne kadar alacağım burada belirlenmiştir. 
            #endregion
            return PagedList<T>.ToPagedList(Model, parameters.PageNumber, parameters.PageSize, queryCount);
        }

        public IQueryable<T> GetAsQueryable()
        {
            return _Entities.AsQueryable();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> where = null, bool AsNoTracking = false, Expression<Func<T, object>> OrderBy = null,   params Expression<Func<T, object>>[] IncludeProperties)
        {
            IQueryable<T> query = _Entities;
            if (IncludeProperties != null)

                foreach (var item in IncludeProperties)
                    query = query.Include(item);

            if (where != null)
                query = query.Where(where);

            if (OrderBy != null)
            {
                
            }

            if (AsNoTracking == true)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync();
        }

        public async Task SoftDeleteAsync(T Entity)
        {
            await Task.Run(() =>
            {
                Entity.IsActive = false;
                _Entities.Update(Entity);
            });
        }

        public async Task UpdateAsync(T Entity)
        {
            await Task.Run(() => { _Entities.Update(Entity); });
        }

    }
}
