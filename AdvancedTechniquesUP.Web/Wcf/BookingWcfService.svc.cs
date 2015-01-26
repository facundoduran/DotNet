using AdvancedTechniques.UP.Services;
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

        public void GetBookings(DateTime date)
        {
            var allbookings = this.bookingService.GetBookingsAfterDate(date);

        }
    }
}
