using Microsoft.EntityFrameworkCore;
using shared.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Generic
{

    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> GetAsync(Expression<Func<T, bool>> whereCondition);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
                           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                           string includeProperties = "");

        IEnumerable<T> GetMany(Expression<Func<T, bool>> whereCondition = null,
                              Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                              string includeProperties = "");
        T GetOne(Expression<Func<T, bool>> whereCondition);
        Task<bool> CreateAsync(T entity);
        T Create(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> RemoveAsync(T entity);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected IUnitOfWork _unitOfWork;
        
        public async Task<T> GetAsync(Expression<Func<T, bool>> whereCondition)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>().Where(whereCondition);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _unitOfWork.Context.Set<T>().ToListAsync();
        }

        public T GetOne(Expression<Func<T, bool>> whereCondition)
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>().Where(whereCondition);
            return query.FirstOrDefault();
        }
        
        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>().ToList();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> whereCondition = null,
                                  Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                  string includeProperties = "")
        {
            IQueryable<T> query = _unitOfWork.Context.Set<T>();

            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<bool> CreateAsync(T entity)
        {
            bool created = false;

            try
            {
                var save = await _unitOfWork.Context.Set<T>().AddAsync(entity);
                if (save != null)                                  
                    created = true;                
            }
            catch (Exception)
            {
                throw;
            }                        
            return created;
        }
        
        public T Create(T entity)
        {
            T entityResult = null;

            try
            {
                var save = _unitOfWork.Context.Set<T>().Add(entity);
                if (save != null)                                  
                    entityResult = save.Entity;
            }
            catch (Exception)
            {
                throw;
            }                        
            return entityResult;
        }
        
        public bool Update(T entity)
        {
            bool updated = false;

            try
            {
                var save = _unitOfWork.Context.Set<T>().Update(entity);

                if (save != null)                                  
                    updated = true;                
            }
            catch (Exception)
            {
                throw;
            }                        
            return updated;
        }
        
        public async Task<bool> UpdateAsync(T entity)
        {
            bool updated = false;

            try
            {
                var save = _unitOfWork.Context.Set<T>().Update(entity);
                await _unitOfWork.Context.SaveChangesAsync();

                if (save != null)                                  
                    updated = true;                
            }
            catch (Exception)
            {
                throw;
            }                        
            return updated;
        }
        
        public bool Remove(T entity)
        {
            bool removed = false;

            try
            {
                var save =  _unitOfWork.Context.Set<T>().Remove(entity);

                if (save != null)                                  
                    removed = true;                
            }
            catch (Exception)
            {
                throw;
            }                        
            return removed;
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            bool removed = false;

            try
            {
                var save =  _unitOfWork.Context.Set<T>().Remove(entity);
                await _unitOfWork.Context.SaveChangesAsync();

                if (save != null)                                  
                    removed = true;                
            }
            catch (Exception)
            {
                throw;
            }                        
            return removed;
        }

  }
}