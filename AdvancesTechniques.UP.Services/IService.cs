using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Services
{
    public interface IService<T> where T : class
    {
        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        T GetById(int entityId);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> criteria);
    }
}
