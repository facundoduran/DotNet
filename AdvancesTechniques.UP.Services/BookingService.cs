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
    public class BookingService : IBookingService
    {
        private IUnitOfWork unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Booking entity)
        {
            try
            {
                IRepository<Booking> repository = new Repository<Booking>(this.unitOfWork);

                repository.Create(entity);

                this.unitOfWork.Commit();
            }
            catch (Exception)
            {
                this.unitOfWork.Rollback();
            }
        }

        public void Edit(Booking entity)
        {
            IRepository<Booking> repository = new Repository<Booking>(this.unitOfWork);

            repository.Update(entity);
        }

        public void Delete(Booking entity)
        {
            IRepository<Booking> repository = new Repository<Booking>(this.unitOfWork);

            repository.Remove(entity);
        }

        public IEnumerable<Booking> GetAll()
        {
            IRepository<Booking> repository = new Repository<Booking>(this.unitOfWork);

            return repository.GetAll();
        }

        public Booking GetById(int entityId)
        {
            IRepository<Booking> repository = new Repository<Booking>(this.unitOfWork);

            Expression<Func<Booking, bool>> criteria = x => x.BookingId == entityId;

            var searchResult = repository.Find(criteria);

            return searchResult.FirstOrDefault();
        }

        public IList<Booking> GetBookingsByCustomer(int customerId)
        {
            IRepository<Booking> repository = new Repository<Booking>(this.unitOfWork);

            Expression<Func<Booking, bool>> criteria = x => x.CustomerId == customerId;

            var searchResult = repository.Find(criteria);

            return searchResult.ToList();
        }


        public int GetOffersByDay(DateTime date)
        {
            IRepository<Booking> repository = new Repository<Booking>(this.unitOfWork);

            Expression<Func<Booking, bool>> criteria = x => x.FromTime <= date;

            var searchResult = repository.Find(criteria);

            return searchResult.Count();
        }

        public IList<Booking> GetBookingsAfterDate(DateTime date)
        {
            IRepository<Booking> repository = new Repository<Booking>(this.unitOfWork);

            Expression<Func<Booking, bool>> criteria = x => x.FromTime <= date;

            return repository.Find(criteria).ToList();
        }


        public IEnumerable<Booking> Find(Expression<Func<Booking, bool>> criteria)
        {
            IRepository<Booking> repository = new Repository<Booking>(this.unitOfWork);

            var searchResult = repository.Find(criteria);

            return searchResult;
        }
    }
}
