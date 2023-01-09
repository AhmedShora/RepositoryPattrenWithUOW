using RepositoryPattrenWithUOW.Core.Consts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattrenWithUOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetAll();
        T FilterBy(Expression<Func<T, bool>> match);

        IEnumerable<T> Find(Expression<Func<T, bool>> match, string[]? includes = null);
        IEnumerable<T> Find(Expression<Func<T, bool>> match, int take, int skip);
        IEnumerable<T> Find(Expression<Func<T, bool>> match, int? take, int? skip,
            Expression<Func<T, object>>? orderBy = null, string orderByDirection = OrderBy.Ascending);

        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);

    }
}
