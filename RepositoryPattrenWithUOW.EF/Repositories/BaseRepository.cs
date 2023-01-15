using Microsoft.EntityFrameworkCore;
using RepositoryPattrenWithUOW.Core.Consts;
using RepositoryPattrenWithUOW.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattrenWithUOW.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AppDbContext _context;
        // private readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public T FilterBy(Expression<Func<T, bool>> criteria)
        {
            return _context.Set<T>().FirstOrDefault(criteria);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.Where(criteria).ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            return _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>>? orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);
            if (take.HasValue)
                query.Take(take.Value);
            if (skip.HasValue)
                query.Skip(skip.Value);
            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query.OrderBy(orderBy);
                else
                    query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id) => _context.Set<T>().Find(id);

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
           // _context.SaveChanges();
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            //_context.SaveChanges();
            return entities;
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);

        }
        public int Count()
        {
            return _context.Set<T>().Count();
        }
        public int Count(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Count();

        }


    }
}
