using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace AdvancedTechniques.UP.Persistence.Sql
{
    public interface IUnitOfWork
    {
        void Commit();

        IDbContext GetDbContext();

        void Rollback();
    }
}
