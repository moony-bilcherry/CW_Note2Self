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

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entity);

        TEntity FindById(int id);

        void Remove(TEntity entity);
        public IEnumerable<TEntity> GetAllWithPropertiesIncluded();
    }
}
