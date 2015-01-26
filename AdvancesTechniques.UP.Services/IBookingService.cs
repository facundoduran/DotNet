using AdvancedTechniques.UP.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Services
{
    public interface IBookingService : IService<Booking>
    {
        IList<Booking> GetBookingsByCustomer(int customerId);

        int GetOffersByDay(DateTime date);

        IList<Booking> GetBookingsAfterDate(DateTime date);
    }
}
