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
    public class CustomerService : ICustomerService
    {
        private IUnitOfWork unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(Customer entity)
        {
            try
            {
                IRepository<Customer> customerRepository = new Repository<Customer>(this.unitOfWork);
                customerRepository.Create(entity);
                unitOfWork.Commit();

            }
            catch (Exception)
            {
                unitOfWork.Rollback();
            }
        }

        public void Edit(Customer entity)
        {
            try
            {
                IRepository<Customer> customerRepository = new Repository<Customer>(this.unitOfWork);
                customerRepository.Update(entity);
                unitOfWork.Commit();
            }
            catch (Exception)
            {
                unitOfWork.Rollback();
            }
        }

        public void Delete(Customer entity)
        {
            try 
	        {
                IRepository<Customer> customerRepository = new Repository<Customer>(this.unitOfWork);
                customerRepository.Remove(entity);
                unitOfWork.Commit();
	        }
            catch (Exception)
            {
                unitOfWork.Rollback();
            }
        }

        public Customer GetById(int entityId) 
        {
            Expression<Func<Customer, bool>> criteria = x => x.CustomerId == entityId;

            var searchResult = this.Find(criteria);

            return searchResult.FirstOrDefault();
        }

        IEnumerable<Customer> IService<Customer>.GetAll()
        {
            IRepository<Customer> customerRepository = new Repository<Customer>(this.unitOfWork);

            return customerRepository.GetAll();
        }

        public IList<Customer> GetCustomerByName(string customerName)
        {
            Expression<Func<Customer, bool>> criteria = x => x.LastName.Contains(customerName);

            return this.Find(criteria).ToList();
        }


        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> criteria)
        {
            IRepository<Customer> customerRepository = new Repository<Customer>(this.unitOfWork);

            return customerRepository.Find(criteria);
        }
    }
}
