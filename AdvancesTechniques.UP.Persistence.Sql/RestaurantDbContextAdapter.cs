using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Persistence.Sql
{
    public class RestaurantDbContextAdapter : IDbContext
    {
        private readonly RestaurantDbContext context;

        public RestaurantDbContextAdapter(RestaurantDbContext context) 
        {
            this.context = context;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public IDbSet<T> Set<T>() where T : class
        {
            return this.context.Set<T>();
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public DbChangeTracker GetDbChangeTracker()
        {
            return this.context.ChangeTracker;
        }

        public DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            return this.context.Entry<T>(entity);
        }
    }
}
