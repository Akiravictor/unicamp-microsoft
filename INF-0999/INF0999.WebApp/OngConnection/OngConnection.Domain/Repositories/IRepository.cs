using OngConnection.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OngConnection.Domain.Repositories
{
    public interface IRepository<T, TKey> where T : Entity<T, TKey>
    {
        void Add(T obj);
        Task AddAsync(T obj);
        void AddRange(IEnumerable<T> list);
        Task AddRangeAsync(IEnumerable<T> list);
        void Update(T obj);
        void Delete(T obj);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T? GetById(TKey id);
        Task<T?> GetByIdAsync(TKey id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
