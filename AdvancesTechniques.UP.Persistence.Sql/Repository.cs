using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Persistence.Sql
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IDbSet<T> DbSet;
        private IUnitOfWork unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.DbSet = this.unitOfWork.GetDbContext().Set<T>();
        }

        public IQueryable<T> AsQueryable()
        {
            return this.DbSet;
        }

        public virtual void Create(T entity) 
        {
            this.DbSet.Add(entity);
        }

        public void Remove(T entity) 
        {
            this.DbSet.Remove(entity);

        }

        public void Update(T entity) 
        {
            this.unitOfWork.GetDbContext().Entry(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this.DbSet.ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where)
        {
            return this.DbSet.Where(where);
        }
    }
}
