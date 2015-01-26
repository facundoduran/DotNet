using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Persistence.Sql
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);

        void Remove(T entity);

        void Update(T entity);

        IQueryable<T> AsQueryable();

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> where);
    }
}
