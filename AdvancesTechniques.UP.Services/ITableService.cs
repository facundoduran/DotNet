using AdvancedTechniques.UP.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Services
{
    public interface ITableService : IService<Table>
    {
        IList<Table> GetTableByDiners(int count);

        Table GetAvailableTable(DateTime fromDate, DateTime toDate, int count);
    }
}
