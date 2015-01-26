using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Persistence.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Services
{
    public class TableService : ITableService
    {
        private IUnitOfWork unitOfWork;

        public TableService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Table entity)
        {
            IRepository<Table> repository = new Repository<Table>(this.unitOfWork);

            repository.Create(entity);
        }

        public void Edit(Table entity)
        {
            IRepository<Table> repository = new Repository<Table>(this.unitOfWork);

            repository.Update(entity);
        }

        public void Delete(Table entity)
        {
            IRepository<Table> repository = new Repository<Table>(this.unitOfWork);

            repository.Remove(entity);
        }

        public IEnumerable<Table> GetAll()
        {
            IRepository<Table> repository = new Repository<Table>(this.unitOfWork);

            return repository.GetAll();
        }


        public Table GetById(int entityId)
        {
            IRepository<Table> customerRepository = new Repository<Table>(this.unitOfWork);

            Expression<Func<Table, bool>> criteria = x => x.TableId == entityId;

            var searchResult = customerRepository.Find(criteria);

            return searchResult.FirstOrDefault();
        }

        public IList<Table> GetTableByDiners(int count)
        {
            IRepository<Table> customerRepository = new Repository<Table>(this.unitOfWork);

            Expression<Func<Table, bool>> criteria = x => x.Capacity == count;

            var searchResult = customerRepository.Find(criteria);

            return searchResult.ToList();
        }

        public Table GetAvailableTable(DateTime fromDate, DateTime toDate, int count)
        {
            IRepository<Table> customerRepository = new Repository<Table>(this.unitOfWork);

            Expression<Func<Table, bool>> criteria = x => x.Capacity == count;

            var searchResult = customerRepository.Find(criteria);

            if (searchResult.Any())
            {
                var tables = searchResult.ToList();

                foreach (var table in tables)
                {
                    bool existOverlap = table.Bookings
                        .Where(
                            b => b.FromTime.ToString("dd/MM/yyyy") == fromDate.ToString("dd/MM/yyyy") &&
                            b.IsOverlap(fromDate, toDate))
                        .Any();

                    if (!existOverlap)
                    {
                        return table;
                    }
                }
            }

            return searchResult.FirstOrDefault();
        }
    }
}
