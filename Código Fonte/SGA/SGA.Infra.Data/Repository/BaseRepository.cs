using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SGA.Application.Repository.Core;
using SGA.Infra.Repository.Context;

namespace SGA.Infra.Repository.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>, IQuery<TEntity> where TEntity : class
    {
        protected readonly SgaContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(SgaContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public TEntity Find(Func<TEntity, bool> expression)
        {
            return DbSet.AsNoTracking().AsEnumerable().Where(expression).FirstOrDefault();
        }

        public ICollection<TEntity> List()
        {
            return DbSet.AsNoTracking().ToList();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Delete(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }
    }
}