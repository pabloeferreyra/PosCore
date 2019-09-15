using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PFSoftware.Inventio.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        void Create(T t);

        Task CreateAsync(T t);

        void Update(T t);

        void Remove(T t);

        List<T> FindAll();

        Task<List<T>> FindAllAsync();

        List<T> FindBy(Expression<Func<T, bool>> predicate);

        Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);

        T FindSingle(Expression<Func<T, bool>> predicate);

        Task<T> FindSingleAsync(Expression<Func<T, bool>> predicate);

        bool Any(Expression<Func<T, bool>> predicate);
    }
}
