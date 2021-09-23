using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Data.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<T> DbSet;

        public Repository(MeuDbContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public virtual async Task Add(T entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task<List<T>> GetALL()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Update(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual void Dispose()
        {
            Db?.Dispose();
        }
    }
}
