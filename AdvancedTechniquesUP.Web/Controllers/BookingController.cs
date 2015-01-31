using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Business.ViewModel;
using AdvancedTechniques.UP.Common.Utils;
using AdvancedTechniques.UP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedTechniques.Web.Controllers
{
    public class BookingController : Controller
    {
        private ICustomerService customerService;
        private IBookingService bookingService;
        private ITableService tableService;

        public BookingController(IBookingService bookingService, ITableService tableService, ICustomerService customerService) 
        {
            this.bookingService = bookingService;
            this.tableService = tableService;
            this.customerService = customerService;
        }
        //
        // GET: /Booking/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create() 
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetOffersByDay() 
        {
            DateTime currentDate = DateTime.Now;

            int offersDay = this.bookingService.GetOffersByDay(currentDate.Date);

            return Json(new { offersDay = offersDay }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(BookingViewModel booking)
        {
            if (ModelState.IsValid)
            {
                Table table = this.tableService.GetAvailableTable(booking.FromTime.Value, booking.ToTime.Value, booking.DinersQuantity);
                string bookingCode = BookingCodeGenerator.GetBookingCode();

                Customer customer = new Customer
                {
                    FirstName = booking.Customer.FirstName,
                    LastName = booking.Customer.LastName,
                    Telephone = booking.Customer.Telephone,
                    Email = booking.Customer.Email
                };

                if (table != null)
                {
                    Booking newBooking = new Booking()
                    {
                        Code = bookingCode,
                        Customer = customer,
                        FromTime = booking.FromTime.Value,
                        ToTime = booking.ToTime.Value,
                        salesChannel = SalesChannel.Web,
                        Table = table
                    };

                    this.bookingService.Add(newBooking);

                    return Json(new { msg = "Success", code = bookingCode }, JsonRequestBehavior.AllowGet);
                }
            }

            return View(booking);
        }

        public ActionResult Search()
        {            
            return View();
        }

        public ActionResult Edit(int bookingId) 
        {
            Booking booking = this.bookingService.GetById(bookingId);

            if (booking != null)
            {
                CustomerViewModel customerViewModel = new CustomerViewModel()
                {
                    FirstName = booking.Customer.FirstName,
                    LastName = booking.Customer.LastName,
                    Telephone = booking.Customer.Telephone,
                    Email = booking.Customer.Email
                };

                BookingViewModel editBooking = new BookingViewModel()
                {
                    Customer = customerViewModel,
                    FromTime = booking.FromTime,
                    ToTime = booking.ToTime
                };

                return View(editBooking);
            }

            return Search();
        }

        public ActionResult Delete(int bookingId) 
        {
            Booking booking = this.bookingService.GetById(bookingId);

            if (booking != null)
            {
                this.bookingService.Delete(booking);
            }

            return View();
        }
	}
}