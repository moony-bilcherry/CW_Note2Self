using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        
        //IEnumerable<TEntity> GetAll();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entity);

        IEnumerable<TEntity> Get();
        TEntity FindById(int id);

        void Remove(TEntity entity);
    }
}
