using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OngConnection.Domain.Repositories;
using OngConnection.Domain.Base;

namespace OngConnection.Infrastructure.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : Entity<T, TKey>
    {
        protected DbContext Db;
        protected DbSet<T> DbSet;

        public Repository(DbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public void Add(T obj)
        {
            DbSet.Add(obj);
        }

        public async Task AddAsync(T obj)
        {
            await DbSet.AddAsync(obj);
        }

        public void AddRange(IEnumerable<T> list)
        {
            DbSet.AddRange(list);
        }

        public async Task AddRangeAsync(IEnumerable<T> list)
        {
            await DbSet.AddRangeAsync(list);
        }

        public void Delete(T obj)
        {
            DbSet.Remove(obj);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return DbSet.AsNoTracking().Where(expression);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await DbSet.AsNoTracking().Where(expression).ToListAsync();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public T? GetById(TKey id)
        {
            return DbSet.Find(id);
        }

        public async Task<T?> GetByIdAsync(TKey id)
        {
            return await DbSet.FindAsync(id);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public void Update(T obj)
        {
            DbSet.Update(obj);
        }
    }
}
