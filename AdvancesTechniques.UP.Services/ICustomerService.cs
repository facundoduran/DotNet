using AdvancedTechniques.UP.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Services
{
    public interface ICustomerService : IService<Customer>
    {
        IList<Customer> GetCustomerByName(string customerName);
    }
}
