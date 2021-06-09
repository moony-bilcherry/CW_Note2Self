using Microsoft.EntityFrameworkCore;
using Note2Self.Data.Extensions;
using Note2Self.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext Context;

        #region Конструктор
        public Repository(DbContext context)
        {
            Context = context;
        }
        #endregion

        #region Методы интерфейса
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
        public void Remove(TEntity entity)
        {
            TEntity en = Context.Set<TEntity>().SingleOrDefault(s => s.Id == entity.Id);
            Context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }
        

        

        public void Update(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
        public void Update(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }
        public TEntity FindById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }
        virtual public IEnumerable<TEntity> GetAllWithPropertiesIncluded()
            =>
             Context.Set<TEntity>().Include(Context.GetIncludePaths<TEntity>()).ToList();

        #endregion


    }
}
