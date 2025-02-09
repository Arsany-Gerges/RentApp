using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Domain.Abstraction
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        T Find(Expression<Func<T, bool>> match);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAllSorted<TKey>(Expression<Func<T, TKey>> keySelector, bool ascending = true);
        Task<IEnumerable<T>> GetAllSortedAsync<TKey>(Expression<Func<T, TKey>> keySelector, bool ascending = true);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);


    }
}
