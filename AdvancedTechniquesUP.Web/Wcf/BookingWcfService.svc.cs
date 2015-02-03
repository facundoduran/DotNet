using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Services;
using AdvancedTechniques.Web.Wcf.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AdvancedTechniques.Web.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetLastBookings" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GetLastBookings.svc or GetLastBookings.svc.cs at the Solution Explorer and start debugging.
    public class BookingWcfService : IBookingWcfService
    {
        private IBookingService bookingService;
        private ICustomerService customerService;
        private ITableService tableService;

        public BookingWcfService(IBookingService bookingService, ICustomerService customerService, ITableService tableService) 
        {
            this.bookingService = bookingService;
            this.customerService = customerService;
            this.tableService = tableService;
        }

        public IList<BookingContract> SynchronizeBookings(DateTime date)
        {
            var bookings = this.bookingService.GetBookingsBetweenDates(date, DateTime.Now);

            IList<BookingContract> bookingContracts = new List<BookingContract>();

            foreach (var booking in bookings)
            {
                TableContract tableContract = new TableContract()
                {                    
                    Capacity = booking.Table.Capacity,
                    Name = booking.Table.Name
                };

                CustomerContract customerContract = new CustomerContract()
                {
                    FirstName = booking.Customer.FirstName,
                    LastName = booking.Customer.LastName,
                    Telephone = booking.Customer.Telephone,
                    Email = booking.Customer.Email
                };

                bookingContracts.Add(
                    new BookingContract()
                    {
                        Customer = customerContract,
                        Table = tableContract,
                        FromTime = booking.FromTime,
                        ToTime = booking.ToTime,
                        salesChannel = SalesChannelContract.Web
                    });
            }

            return bookingContracts;
        }
    }
}
