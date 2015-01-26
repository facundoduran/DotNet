using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Persistence.Sql
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IDbContext context;

        public UnitOfWork(IDbContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                context.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public IDbContext GetDbContext()
        {
            return this.context;
        }

        public void Rollback()
        {
            var changeTracker = this.context.GetDbChangeTracker();

            changeTracker
                .Entries()
                .ToList()
                .ForEach(entry => entry.State = EntityState.Unchanged);
        }
    }
}
