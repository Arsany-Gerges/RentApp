using Microsoft.EntityFrameworkCore;
using RentApp.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected RentAppDbContext _context;
        protected DbSet<T> _dbSet;
        public BaseRepository(RentAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return _dbSet.SingleOrDefault(match);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public  IEnumerable<T> GetAllSorted<TKey>(System.Linq.Expressions.Expression<Func<T, TKey>> keySelector, bool ascending = true)
        {
            return ascending ?
                 _dbSet.OrderBy(keySelector).ToList()
                : _dbSet.OrderByDescending(keySelector).ToList();
        }

        public async Task<IEnumerable<T>> GetAllSortedAsync<TKey>(System.Linq.Expressions.Expression<Func<T, TKey>> keySelector, bool ascending = true)
        {
            return ascending ?
                await _dbSet.OrderBy(keySelector).ToListAsync()
                : await _dbSet.OrderByDescending(keySelector).ToListAsync();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
